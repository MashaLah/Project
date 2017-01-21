using DAL.Interface.DTO;
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
    public class TopicRepository : ITopicRepository
    {
        private readonly DbContext context;

        public TopicRepository(DbContext uow)
        {
            context = uow;
        }

        public IEnumerable<DALTopic> GetAll()
        {
            return context.Set<Topic>().Select(topic => new DALTopic()
            {
                Id = topic.Id,
                Title = topic.Title,
                Description = topic.Description,
                UserId = topic.UserId,
                Date = topic.Date,
                SectionId = topic.SectionId,
                LastUpdatedDate = topic.LastUpdatedDate
            });
        }

        public DALTopic GetById(int key)
        {
            var ormTopic = context.Set<Topic>().FirstOrDefault(topic => topic.Id == key);
            return new DALTopic()
            {
                Id = ormTopic.Id,
                Title = ormTopic.Title,
                Description = ormTopic.Description,
                UserId = ormTopic.UserId,
                Date = ormTopic.Date,
                SectionId = ormTopic.SectionId,
                LastUpdatedDate = ormTopic.LastUpdatedDate
            };
        }

        /*public IEnumerable<DALTopic> GetByPredicate(Expression<Func<DALTopic, bool>> f)
        {
            //Expression<Func<DalUser, bool>> -> Expression<Func<User, bool>> (!)
            throw new NotImplementedException();
        }*/

        public void Create(DALTopic e)
        {
            var topic = new Topic()
            {
                Title = e.Title,
                Description = e.Description,
                UserId = e.UserId,
                Date = e.Date,
                SectionId = e.SectionId,
                LastUpdatedDate = e.LastUpdatedDate
                //ForumId = forumId
            };
            context.Set<Topic>().Add(topic);
        }

        public void Delete(DALTopic e)
        {
            var topic = new Topic()
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                UserId = e.UserId,
                Date = e.Date,
                SectionId = e.SectionId,
                LastUpdatedDate=e.LastUpdatedDate
            };
            topic = context.Set<Topic>().Single(t => t.Id == topic.Id);
            context.Set<Topic>().Remove(topic);
        }

        public void Update(DALTopic entity)
        {
            var topic = context.Set<Topic>().FirstOrDefault(t => t.Id == entity.Id);
            topic.Title = entity.Title;
            topic.Description = entity.Description;
            topic.UserId = entity.UserId;
            topic.Date = entity.Date;
            topic.SectionId = entity.SectionId;
            topic.LastUpdatedDate = entity.LastUpdatedDate;
           // context.Entry(topic).State = EntityState.Modified;
        }

    }
}
