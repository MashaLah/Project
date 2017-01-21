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
                //Forums = new List<DALForum>(),
            };
            /*var forums = sectionEntity.Forums.Select(forum => new DALForum()
            {
                Id = forum.Id,
                SectionId = forum.SectionId,
                Title = forum.Title,
                UserId = forum.UserId,
                Date = forum.Date,
            });

            foreach (var forum in forums)
            {
                dalSection.Forums.Add(forum);
            }*/
            return dalSection;
        }

        public static SectionEntity ToBllSection(this DALSection dalSection)
        {
            SectionEntity section = new SectionEntity()
            {
                Id = dalSection.Id,
                Name = dalSection.Name,
                //Forums=new List<ForumEntity>(),
            };
            /*var forums = dalSection.Forums.Select(forum => new ForumEntity()
            {
                Id = forum.Id,
                SectionId = forum.SectionId,
                Title = forum.Title,
                UserId = forum.UserId,
                Date = forum.Date,
            });

            foreach (var forum in forums)
            {
                section.Forums.Add(forum);
            }*/
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
            return new DALTopic()
            {
                Id = topicEntity.Id,
                Title = topicEntity.Title,
                Description = topicEntity.Description,
                UserId = topicEntity.UserId,
                Date = topicEntity.Date,
                SectionId = topicEntity.SectionId,
                LastUpdatedDate = topicEntity.LastUpdatedDate,
            };
        }

        public static TopicEntity ToBllTopic(this DALTopic dalTopic)
        {
            return new TopicEntity()
            {
                Id = dalTopic.Id,
                Title = dalTopic.Title,
                Description = dalTopic.Description,
                UserId = dalTopic.UserId,
                Date = dalTopic.Date,
                SectionId = dalTopic.SectionId,
                LastUpdatedDate = dalTopic.LastUpdatedDate,
            };
        }

        public static DALPost ToDalPost(this PostEntity postEntity)
        {
            return new DALPost()
            {
                Id = postEntity.Id,
                TopicId = postEntity.TopicId,
                Text = postEntity.Text,
                UserId = postEntity.UserId,
                Date = postEntity.Date
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
                Date = dalPost.Date
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

        public static UserEntity ToBllUser(this DALUser dalUser)
        {
            return new UserEntity()
            {
                Id = dalUser.Id,
                Password = dalUser.Password,
                Email = dalUser.Email,
                CreationDate = dalUser.CreationDate,
                //Image = user.Image,
                RoleId = dalUser.RoleId
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
