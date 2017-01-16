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
    public class TopicService : ITopicService
    {
        private readonly IUnitOfWork uow;
        private readonly ITopicRepository topicRepository;

        public TopicService(IUnitOfWork uow, ITopicRepository repository)
        {
            this.uow = uow;
            topicRepository = repository;
        }

        public TopicEntity GetTopicEntity(int id)
        {
            return topicRepository.GetById(id).ToBllTopic();
        }

        public IEnumerable<TopicEntity> GetAllTopicEntities()
        {
            return topicRepository.GetAll().Select(topic => topic.ToBllTopic());
        }

        public IEnumerable<TopicEntity> GetTopicsByPredicate(Expression<Func<TopicEntity, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void CreateTopic(TopicEntity topic)
        {
            topicRepository.Create(topic.ToDalTopic());
            uow.Commit();
        }

        public void DeleteTopic(TopicEntity topic)
        {
            topicRepository.Delete(topic.ToDalTopic());
            uow.Commit();
        }

        public void UpdateTopic(TopicEntity topic)
        {
            topicRepository.Update(topic.ToDalTopic());
            uow.Commit();
        }
    }
}
