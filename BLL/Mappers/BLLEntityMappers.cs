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
               // Topics = new List<DALTopic>(),
            };
           /* var topics = sectionEntity.Topics;*//*.Select(topic => new DALTopic()
            {
                Id = topic.Id,
                SectionId = topic.SectionId,
                Title = topic.Title,
                UserId = topic.UserId,
                Date = topic.Date,
                LastUpdatedDate= topic.LastUpdatedDate,
                Description= topic.Description
            });*/

           /* foreach (var topic in topics)
            {
                dalSection.Topics.Add(topic.ToDalTopic());
            }*/
            return dalSection;
        }

        public static SectionEntity ToBllSection(this DALSection dalSection)
        {
            SectionEntity section = new SectionEntity()
            {
                Id = dalSection.Id,
                Name = dalSection.Name,
                Topics=new List<TopicEntity>(),
            };
            var topics = dalSection.Topics;/*.Select(topic => new TopicEntity()
            {
                Id = topic.Id,
                SectionId = topic.SectionId,
                Title = topic.Title,
                UserId = topic.UserId,
                Date = topic.Date,
                LastUpdatedDate=topic.LastUpdatedDate,
                Description=topic.Description
            });*/

            foreach (var topic in topics)
            {
                section.Topics.Add(topic.ToBllTopic());
            }
            return section;
        }

        public static DALForum ToDalForum(this ForumEntity forumEntity)
        {
            return new DALForum()
            {
                Id = forumEntity.Id,
                SectionId = forumEntity.SectionId,
                Title = forumEntity.Title,
                UserId = forumEntity.UserId,
                Date = forumEntity.Date
            };
        }

        public static ForumEntity ToBllForum(this DALForum dalForum)
        {
            return new ForumEntity()
            {
                Id = dalForum.Id,
                SectionId = dalForum.SectionId,
                Title = dalForum.Title,
                UserId = dalForum.UserId,
                Date = dalForum.Date
            };
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
                SectionId = topicEntity.SectionId,
                LastUpdatedDate = topicEntity.LastUpdatedDate,
                //Posts = new List<DALPost>()
            };
           /* var posts = topicEntity.Posts.Select(post => post.ToDalPost());new DALPost()
            {
                Id = post.Id,
                TopicId = post.TopicId,
                Text = post.Text,
                UserId = post.UserId,
                Date = post.Date
            });*/

           /* foreach (var post in posts)
            {
                dalTopic.Posts.Add(post);
            }*/
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
                SectionId = dalTopic.SectionId,
                LastUpdatedDate = dalTopic.LastUpdatedDate,
                Posts = new List<PostEntity>(),
                User=dalTopic.User.ToBllUser()
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
                //Image = userEntity.Image,
                RoleId = userEntity.RoleId
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
            return new UserEntity()
            {
                Id = dalUser.Id,
                Password = dalUser.Password,
                Email = dalUser.Email,
                CreationDate = dalUser.CreationDate,
                //Image = user.Image,
                RoleId = dalUser.RoleId,
                Profile=dalUser.Profile.ToBllProfile()
            };
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
