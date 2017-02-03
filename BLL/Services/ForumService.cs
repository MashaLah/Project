using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Mappers;

namespace BLL.Services
{
    public class ForumService:IForumService
    {
        private readonly IUnitOfWork uow;
        private readonly IForumRepository forumRepository;

        public ForumService(IUnitOfWork uow, IForumRepository repository)
        {
            this.uow = uow;
            forumRepository = repository;
        }

        public ForumEntity GetForumEntity(int id)
        {
            return forumRepository.GetById(id).ToBllForum();
        }

        public IEnumerable<ForumEntity> GetAllForumEntities()
        {
            return forumRepository.GetAll().Select(topic => topic.ToBllForum());
        }

        public void CreateForum(ForumEntity forum)
        {
            forumRepository.Create(forum.ToDalForum());
            uow.Commit();
        }

        public void DeleteForum(ForumEntity forum)
        {
            forumRepository.Delete(forum.ToDalForum());
            uow.Commit();
        }

        public void UpdateForum(ForumEntity forum)
        {
            forumRepository.Update(forum.ToDalForum());
            uow.Commit();
        }
    }
}
