using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
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
            var allPosts = context.Set<Post>().OrderByDescending(p=>p.Date);
            List<DALPost> posts = new List<DALPost>();
            foreach (var post in allPosts)
            {
                posts.Add(post.ToDALPost());
            }
            return posts;
        }

        public IEnumerable<DALPost> GetModeratoredPosts()
        {
            var allPosts = context.Set<Post>().Where(post => post.StateId != 3).OrderByDescending(p => p.Date);
            List<DALPost> posts = new List<DALPost>();
            foreach (var post in allPosts)
            {
                posts.Add(post.ToDALPost());
            }
            return posts;
        }

        public DALPost GetById(int key)
        {
            var post = context.Set<Post>().FirstOrDefault(p => p.Id == key).ToDALPost();
            return post;
        }

        public void Create(DALPost e) 
        {
            var post = new Post()
            {
                TopicId = e.TopicId,
                Text = e.Text,
                UserId = e.UserId,
                Date = e.Date,
                StateId=e.StateId
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
                Date = e.Date,
                StateId=e.StateId
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
            post.StateId = entity.StateId;
        }

    }
}
