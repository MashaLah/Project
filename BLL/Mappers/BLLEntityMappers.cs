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
            return new DALSection()
            {
                Id = sectionEntity.Id,
                Name = sectionEntity.Name
            };
        }

        public static SectionEntity ToBllSection(this DALSection dalUser)
        {
            return new SectionEntity()
            {
                Id = dalUser.Id,
                Name = dalUser.Name
            };
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
                ForumId = topicEntity.ForumId
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
                ForumId = dalTopic.ForumId
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
                Name = profileEntity.Login,
                UserId=profileEntity.UserId,
                LastUpdateDate=profileEntity.LastUpdateDate
            };
        }

        public static ProfileEntity ToBllProfile(this DALProfile dalProfile)
        {
            return new ProfileEntity()
            {
                Id = dalProfile.Id,
                Login = dalProfile.Name,
                UserId = dalProfile.UserId,
                LastUpdateDate = dalProfile.LastUpdateDate
            };
        }
    }
}
