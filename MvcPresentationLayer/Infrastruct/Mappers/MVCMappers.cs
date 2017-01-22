using BLL.Interface.Entities;
using MvcPresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPresentationLayer.Infrastruct.Mappers
{
    public static class MVCMappers
    {
        public static Section ToMvcSection(this SectionEntity sectionEntity)
        {
            Section section = new Section()
            {
                Id = sectionEntity.Id,
                Name = sectionEntity.Name,
                Topics = new List<Topic>()
            };
            var topics = sectionEntity.Topics.Select(topic => new Topic()
            {
                Id = topic.Id,
                SectionId = topic.SectionId,
                Title = topic.Title,
                UserId = topic.UserId,
                Date = topic.Date,
                LastUpdatedDate=topic.LastUpdatedDate,
                Description=topic.Description
            });

            foreach (var topic in topics)
            {
                section.Topics.Add(topic);
            }
            return section;
        }

        public static SectionEntity ToBllSection(this Section section)
        {
            SectionEntity sectionEntity = new SectionEntity()
            {
                Id = section.Id,
                Name = section.Name,
                Topics= new List<TopicEntity>()
                // RoleId = (int)userViewModel.Role
            };
            var topics = sectionEntity.Topics.Select(topic => new TopicEntity()
            {
                Id = topic.Id,
                SectionId = topic.SectionId,
                Title = topic.Title,
                UserId = topic.UserId,
                Date = topic.Date,
                Description=topic.Description,
                LastUpdatedDate=topic.LastUpdatedDate
            });

            foreach (var topic in topics)
            {
                sectionEntity.Topics.Add(topic);
            }
            return sectionEntity;
        }

        public static Forum ToMvcForum(this ForumEntity forumEntity)
        {
            return new Forum()
            {
                Id = forumEntity.Id,
                SectionId = forumEntity.SectionId,
                Title=forumEntity.Title,
                Date=forumEntity.Date,
                //Section=(Section)forumEntity.SectionId
                // Forums = (Forum)sectionEntity
            };
        }

        public static ForumEntity ToBllForum(this Forum forum)
        {
            return new ForumEntity()
            {
                Id = forum.Id,
                SectionId = forum.SectionId,
                Title = forum.Title,
                Date = forum.Date,
                UserId=forum.UserId
                // RoleId = (int)userViewModel.Role
            };
        }

        public static Topic ToMvcTopic(this TopicEntity topicEntity)
        {
            return new Topic()
            {
                Id = topicEntity.Id,
                SectionId = topicEntity.SectionId,
                Title = topicEntity.Title,
                Date = topicEntity.Date,
                Description=topicEntity.Description,
                LastUpdatedDate=topicEntity.LastUpdatedDate
                //Section=(Section)forumEntity.SectionId
                // Forums = (Forum)sectionEntity
            };
        }

        public static TopicEntity ToBllTopic(this Topic topic)
        {
            return new TopicEntity()
            {
                Id = topic.Id,
                SectionId = topic.SectionId,
                UserId=topic.UserId,
                Title = topic.Title,
                Date = topic.Date,
                Description = topic.Description,
                LastUpdatedDate=topic.LastUpdatedDate
                // RoleId = (int)userViewModel.Role
            };
        }

        public static Post ToMvcPost(this PostEntity postEntity)
        {
            return new Post()
            {
                Id = postEntity.Id,
                TopicId = postEntity.TopicId,
                Text = postEntity.Text,
                Date = postEntity.Date,
                //Section=(Section)forumEntity.SectionId
                // Forums = (Forum)sectionEntity
            };
        }

        public static PostEntity ToBllPost(this Post post)
        {
            return new PostEntity()
            {
                Id = post.Id,
                TopicId = post.TopicId,
                Text = post.Text,
                Date = post.Date,
                // RoleId = (int)userViewModel.Role
            };
        }

        public static Role ToMvcRole(this RoleEntity roleEntity)
        {
            return new Role()
            {
                
            };
        }

        public static RoleEntity ToBllRole(this Role usroleer)
        {
            return new RoleEntity()
            {
                
            };
        }

        public static User ToMvcUser(this UserEntity userEntity)
        {
            return new User()
            {
                Email = userEntity.Email,
                CreationDate = userEntity.CreationDate,
                //Role = userEntity.RoleId
            };
        }

        public static UserEntity ToBllUser(this User user)
        {
            return new UserEntity()
            {
                Email = user.Email,
                CreationDate = user.CreationDate,
                // Id = user.Id,
                //  Login =user.Login,
                //Password 
                //Email 
                // public byte[] Image { get; set; }
                //RoleId 
            };
        }

        public static ProfileViewModel ToMvcProfile(this ProfileEntity profileEntity)
        {
            return new ProfileViewModel()
            {
                Id = profileEntity.Id,
                Login = profileEntity.Login,
                LastUpdateDate = profileEntity.LastUpdateDate,
                UserId = profileEntity.UserId,
                Image = profileEntity.Image,
                ImageMimeType=profileEntity.ImageMimeType
            };
        }

        public static ProfileEntity ToBllProfile(this ProfileViewModel profile)
        {
            return new ProfileEntity()
            {
                Id = profile.Id,
                Login = profile.Login,
                LastUpdateDate = profile.LastUpdateDate,
                UserId = profile.UserId,
                Image = profile.Image,
                ImageMimeType=profile.ImageMimeType
            };
        }
    }
}