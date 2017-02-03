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
    public class TopicRepository : ITopicRepository
    {
        private readonly DbContext context;

        public TopicRepository(DbContext uow)
        {
            context = uow;
        }

        public IEnumerable<DALTopic> GetAll()
        {
            return context.Set<Topic>().Select(topic => topic.ToDalTopic());
        }

        public DALTopic GetById(int key)
        {
            Topic ormTopic = context.Set<Topic>().FirstOrDefault(topic => topic.Id == key);
            return ormTopic.ToDalTopic();
        }

        public void Create(DALTopic e)
        {
            Topic topic = e.ToOrmTopic();
            context.Set<Topic>().Add(topic);
        }

        public void Delete(DALTopic e)
        {
            var topic = e.ToOrmTopic();
            topic = context.Set<Topic>().Single(t => t.Id == topic.Id);
            context.Set<Topic>().Remove(topic);
        }

        public void Update(DALTopic entity)
        {
            var topic = context.Set<Topic>().FirstOrDefault(t => t.Id == entity.Id);
            topic.Title = entity.Title;
            topic.Description = entity.Description;
            topic.LastUpdatedDate = entity.LastUpdatedDate;
            topic.ForumId = entity.ForumId;
            topic.StateId = entity.StateId;
        }

    }
}
