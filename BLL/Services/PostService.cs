using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PostService : IPostService 
    {
        private readonly IUnitOfWork uow;
        private readonly IPostRepository postRepository;

        public PostService(IUnitOfWork uow, IPostRepository repository)
        {
            this.uow = uow;
            postRepository = repository;
        }

        public PostEntity GetPostEntity(int id)
        {
            return postRepository.GetById(id).ToBllPost();
        }

        public IEnumerable<PostEntity> GetAllPostEntities()
        {
            return postRepository.GetAll().Select(post => post.ToBllPost());
        }

        public IEnumerable<PostEntity> GetApprovedPostEntities()
        {
            return postRepository.GetApprovedPosts().Select(post => post.ToBllPost());
        }

        public IEnumerable<PostEntity> GetPostsByPredicate(Expression<Func<PostEntity, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void CreatePost(PostEntity post)
        {
            postRepository.Create(post.ToDalPost());
            uow.Commit();
        }

        public void DeletePost(PostEntity post)
        {
            postRepository.Delete(post.ToDalPost());
            uow.Commit();
        }

        public void UpdatePost(PostEntity post)
        {
            postRepository.Update(post.ToDalPost());
            uow.Commit();
        }
    }
}
