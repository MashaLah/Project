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
            var topics = sectionEntity.Topics.Select(topic => topic.ToMvcTopic());/*new Topic()
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
                // Topics= new List<TopicEntity>()
                // RoleId = (int)userViewModel.Role
            };
            /* var topics = section.Topics.Select(topic => topic.ToBllTopic());*/ /*new TopicEntity()
             {
                 Id = topic.Id,
                 SectionId = topic.SectionId,
                 Title = topic.Title,
                 UserId = topic.UserId,
                 Date = topic.Date,
                 Description=topic.Description,
                 LastUpdatedDate=topic.LastUpdatedDate
             });*/

            /* foreach (var topic in topics)
             {
                 sectionEntity.Topics.Add(topic);
             }*/
            return sectionEntity;
        }

        public static Topic ToMvcTopic(this TopicEntity topicEntity)
        {
            Topic topic = new Topic()
            {
                Id = topicEntity.Id,
                SectionId = topicEntity.SectionId,
                Title = topicEntity.Title,
                Date = topicEntity.Date,
                Description = topicEntity.Description,
                LastUpdatedDate = topicEntity.LastUpdatedDate,
                Posts = new List<Post>(),
                User = topicEntity.User.ToMvcUser()
            };

            var posts = topicEntity.Posts.Select(post => post.ToMvcPost());

            foreach (var post in posts)
            {
                topic.Posts.Add(post);
            }
            return topic;
        }

        public static TopicEntity ToBllTopic(this Topic topic)
        {
            TopicEntity topicEntity = new TopicEntity()
            {
                Id = topic.Id,
                SectionId = topic.SectionId,
                UserId = topic.UserId,
                Title = topic.Title,
                Date = topic.Date,
                Description = topic.Description,
                LastUpdatedDate = topic.LastUpdatedDate,
            };
            return topicEntity;
        }

        public static Post ToMvcPost(this PostEntity postEntity)
        {
            return new Post()
            {
                Id = postEntity.Id,
                TopicId = postEntity.TopicId,
                Text = postEntity.Text,
                Date = postEntity.Date,
                UserId = postEntity.UserId,
                User = postEntity.User.ToMvcUser(),
                StateId = postEntity.StateId,
                State = postEntity.State.ToMvcState()
            };
        }

        public static State ToMvcState(this StateEntity stateEntity)
        {
            return new State()
            {
                Id=stateEntity.Id,
                Name=stateEntity.State
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
                UserId = post.UserId,
                StateId = post.StateId
            };
        }

        public static User ToMvcUser(this UserEntity userEntity)
        {
            User user = new User()
            {
                Email = userEntity.Email,
                CreationDate = userEntity.CreationDate,
            };
            if (userEntity.Profile != null)
                user.Profile = userEntity.Profile.ToMvcProfile();
            return user;

        }

        public static UserEntity ToBllUser(this User user)
        {
            return new UserEntity()
            {
                Email = user.Email,
                CreationDate = user.CreationDate,
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