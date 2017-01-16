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
            return new Section()
            {
                Id = sectionEntity.Id,
                Name = sectionEntity.Name,
               // Forums = (Forum)sectionEntity
            };
        }

        public static SectionEntity ToBllSection(this Section section)
        {
            return new SectionEntity()
            {
                Id = section.Id,
                Name = section.Name,
               // RoleId = (int)userViewModel.Role
            };
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
                // RoleId = (int)userViewModel.Role
            };
        }

        public static Topic ToMvcTopic(this TopicEntity topicEntity)
        {
            return new Topic()
            {
                Id = topicEntity.Id,
                ForumId = topicEntity.ForumId,
                Title = topicEntity.Title,
                Date = topicEntity.Date,
                Description=topicEntity.Description,
                //Section=(Section)forumEntity.SectionId
                // Forums = (Forum)sectionEntity
            };
        }

        public static TopicEntity ToBllTopic(this Topic topic)
        {
            return new TopicEntity()
            {
                Id = topic.Id,
                ForumId = topic.ForumId,
                Title = topic.Title,
                Date = topic.Date,
                Description = topic.Description,
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
    }
}