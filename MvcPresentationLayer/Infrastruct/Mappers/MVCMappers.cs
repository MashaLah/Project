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
                Forums = new List<Forum>()
            };
            var forums = sectionEntity.Forums.Select(forum => forum.ToMvcForum());

            foreach (var forum in forums)
            {
                section.Forums.Add(forum);
            }
            return section;
        }

        public static SectionEntity ToBllSection(this Section section)
        {
            SectionEntity sectionEntity = new SectionEntity()
            {
                Id = section.Id,
                Name = section.Name,
            };
            return sectionEntity;
        }

        public static Forum ToMvcForum(this ForumEntity forumEntity)
        {
            Forum forum = new Forum()
            {
                Id = forumEntity.Id,
                SectionId = forumEntity.SectionId,
                Title = forumEntity.Title,
                Description = forumEntity.Description,
                LastUpdatedDate = forumEntity.LastUpdatedDate,
                Topics = new List<Topic>(),
            };

            var topics = forumEntity.Topics.Select(topic => topic.ToMvcTopic());

            foreach (var topic in topics)
            {
                forum.Topics.Add(topic);
            }
            return forum;
        }

        public static ForumEntity ToBllForum(this Forum forum)
        {
            ForumEntity forumEntity = new ForumEntity()
            {
                Id = forum.Id,
                SectionId = forum.SectionId,
                Title = forum.Title,
                Description = forum.Description,
                LastUpdatedDate = forum.LastUpdatedDate,
            };
            return forumEntity;
        }

        public static Topic ToMvcTopic(this TopicEntity topicEntity)
        {
            Topic topic = new Topic()
            {
                Id = topicEntity.Id,
                ForumId = topicEntity.ForumId,
                Title = topicEntity.Title,
                Date = topicEntity.Date,
                Description = topicEntity.Description,
                LastUpdatedDate = topicEntity.LastUpdatedDate,
                Posts = new List<Post>(),
                User = topicEntity.User.ToMvcUser(),
                StateId=topicEntity.StateId
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
                ForumId = topic.ForumId,
                UserId = topic.UserId,
                Title = topic.Title,
                Date = topic.Date,
                Description = topic.Description,
                LastUpdatedDate = topic.LastUpdatedDate,
                StateId=topic.StateId
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

        public static Role ToMvcRole(this RoleEntity roleEntity)
        {
            return new Role()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name
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
                Id=userEntity.Id,
                Email = userEntity.Email,
                CreationDate = userEntity.CreationDate,
                RoleId=userEntity.RoleId,
                Role=userEntity.Role.ToMvcRole()         
            };
            if (userEntity.Profile != null)
                user.Profile = userEntity.Profile.ToMvcProfile();
            return user;

        }

        public static UserEntity ToBllUser(this User user)
        {
            return new UserEntity()
            {
                Id = user.Id,
                Email = user.Email,
                CreationDate = user.CreationDate,
                RoleId = user.RoleId,
                Password = user.Password
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