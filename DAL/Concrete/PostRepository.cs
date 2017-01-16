﻿using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class PostRepository : IPostRepository
    {
        private readonly DbContext context;

        public PostRepository(DbContext uow)
        {
            context = uow;
        }

        public IEnumerable<DALPost> GetAll()
        {
            return context.Set<Post>().Select(post => new DALPost()
            {
                Id = post.Id,
                TopicId = post.TopicId,
                Text = post.Text,
                UserId = post.UserId,
                Date = post.Date
            });
        }

        public DALPost GetById(int key)
        {
            var post = context.Set<Post>().FirstOrDefault(p => p.Id == key);
            return new DALPost()
            {
                Id = post.Id,
                TopicId = post.TopicId,
                Text = post.Text,
                UserId = post.UserId,
                Date = post.Date
            };
        }

        /* public IEnumerable<DALPost> GetByPredicate(Expression<Func<DALPost, bool>> f)
         {
             //Expression<Func<DalUser, bool>> -> Expression<Func<User, bool>> (!)
             throw new NotImplementedException();
         }*/

        public void Create(DALPost e) 
        {
            var post = new Post()
            {
                TopicId = e.TopicId,
                //TopicId = topicId,
                Text = e.Text,
                UserId = e.UserId,
                Date = e.Date
            };
            context.Set<Post>().Add(post);
        }

        public void Delete(DALPost e)
        {
            var post = new Post()
            {
                Id = e.Id,
                TopicId = e.TopicId,
                Text = e.Text,
                UserId = e.UserId,
                Date = e.Date
            };
            post = context.Set<Post>().Single(p => p.Id == post.Id);
            context.Set<Post>().Remove(post);
        }

        public void Update(DALPost entity)
        {
            var post = context.Set<Post>().Single(p => p.Id == entity.Id);
            post.TopicId = entity.TopicId;
            post.Text = entity.Text;
            post.UserId = entity.UserId;
            post.Date = entity.Date;
        }

    }
}
