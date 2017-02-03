using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class BLLEntityMappers
    {
        public static DALSection ToDalSection(this SectionEntity sectionEntity)
        {
            DALSection dalSection = new DALSection()
            {
                Id = sectionEntity.Id,
                Name = sectionEntity.Name,
            };
            return dalSection;
        }

        public static SectionEntity ToBllSection(this DALSection dalSection)
        {
            SectionEntity section = new SectionEntity()
            {
                Id = dalSection.Id,
                Name = dalSection.Name,
                Forums=new List<ForumEntity>(),
            };
            var forums = dalSection.Forums;

            foreach (var forum in forums)
            {
                section.Forums.Add(forum.ToBllForum());
            }
            return section;
        }

        public static DALForum ToDalForum(this ForumEntity forumEntity)
        {
            DALForum dalForum = new DALForum()
            {
                Id = forumEntity.Id,
                Title = forumEntity.Title,
                Description = forumEntity.Description,
                LastUpdatedDate = forumEntity.LastUpdatedDate,
                SectionId = forumEntity.SectionId,
            };
            return dalForum;
        }

        public static ForumEntity ToBllForum(this DALForum dalForum)
        {
            ForumEntity forum = new ForumEntity()
            {
                Id = dalForum.Id,
                Title = dalForum.Title,
                Description = dalForum.Description,
                LastUpdatedDate = dalForum.LastUpdatedDate,
                SectionId = dalForum.SectionId,
                Topics = new List<TopicEntity>(),
            };

            var topics = dalForum.Topics.Select(topic => topic.ToBllTopic());

            foreach (var topic in topics)
            {
                forum.Topics.Add(topic);
            }
            return forum;
        }

        public static DALTopic ToDalTopic(this TopicEntity topicEntity)
        {
            DALTopic dalTopic = new DALTopic()
            {
                Id = topicEntity.Id,
                Title = topicEntity.Title,
                Description = topicEntity.Description,
                UserId = topicEntity.UserId,
                Date = topicEntity.Date,
                ForumId = topicEntity.ForumId,
                LastUpdatedDate = topicEntity.LastUpdatedDate,
                StateId=topicEntity.StateId
            };
            return dalTopic;
        }

        public static TopicEntity ToBllTopic(this DALTopic dalTopic)
        {
            TopicEntity topic = new TopicEntity()
            {
                Id = dalTopic.Id,
                Title = dalTopic.Title,
                Description = dalTopic.Description,
                UserId = dalTopic.UserId,
                Date = dalTopic.Date,
                ForumId = dalTopic.ForumId,
                LastUpdatedDate = dalTopic.LastUpdatedDate,
                Posts = new List<PostEntity>(),
                User=dalTopic.User.ToBllUser(),
                StateId =dalTopic.StateId
            };

            var posts = dalTopic.Posts.Select(post => post.ToBllPost());

            foreach (var post in posts)
            {
                topic.Posts.Add(post);
            }
            return topic;
        }

        public static DALPost ToDalPost(this PostEntity postEntity)
        {
            return new DALPost()
            {
                Id = postEntity.Id,
                TopicId = postEntity.TopicId,
                Text = postEntity.Text,
                UserId = postEntity.UserId,
                Date = postEntity.Date,
                StateId = postEntity.StateId
            };
        }

        public static PostEntity ToBllPost(this DALPost dalPost)
        {
            return new PostEntity()
            {
                Id = dalPost.Id,
                TopicId = dalPost.TopicId,
                Text = dalPost.Text,
                UserId = dalPost.UserId,
                Date = dalPost.Date,
                User = dalPost.User.ToBllUser(),
                StateId=dalPost.StateId,
                State=dalPost.State.ToBllState()
            };
        }

        public static DALUser ToDalUser(this UserEntity userEntity)
        {
            return new DALUser()
            {
                Id = userEntity.Id,
                Password = userEntity.Password,
                Email = userEntity.Email,
                CreationDate = userEntity.CreationDate,
                RoleId = userEntity.RoleId,
                IsBanned=userEntity.IsBanned
            };
        }

        public static StateEntity ToBllState(this DALState state)
        {
            return new StateEntity()
            {
                Id = state.Id,
                State = state.State
            };
        }

        public static UserEntity ToBllUser(this DALUser dalUser)
        {
            UserEntity userEntity= new UserEntity()
            {
                Id = dalUser.Id,
                Password = dalUser.Password,
                Email = dalUser.Email,
                CreationDate = dalUser.CreationDate,
                RoleId = dalUser.RoleId,
                IsBanned=dalUser.IsBanned
            };
            if (dalUser.Profile != null)
                userEntity.Profile = dalUser.Profile.ToBllProfile();
            return userEntity;
        }

        public static DALRole ToDalRole(this RoleEntity roleEntity)
        {
            return new DALRole()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name
            };
        }

        public static RoleEntity ToBllRole(this DALRole dalRole)
        {
            return new RoleEntity()
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };
        }

        public static DALProfile ToDalProfile(this ProfileEntity profileEntity)
        {
            return new DALProfile()
            {
                Id = profileEntity.Id,
                Login = profileEntity.Login,
                UserId = profileEntity.UserId,
                LastUpdateDate = profileEntity.LastUpdateDate,
                Image = profileEntity.Image,
                ImageMimeType=profileEntity.ImageMimeType
            };
        }

        public static ProfileEntity ToBllProfile(this DALProfile dalProfile)
        {
            return new ProfileEntity()
            {
                Id = dalProfile.Id,
                Login = dalProfile.Login,
                UserId = dalProfile.UserId,
                LastUpdateDate = dalProfile.LastUpdateDate,
                Image = dalProfile.Image,
                ImageMimeType=dalProfile.ImageMimeType
            };
        }
    }
}
