using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface ITopicService
    {
        TopicEntity GetTopicEntity(int id);
        IEnumerable<TopicEntity> GetAllTopicEntities();
        IEnumerable<TopicEntity> GetTopicsByPredicate(Expression<Func<TopicEntity, bool>> f);
        void CreateTopic(TopicEntity topic);
        void DeleteTopic(TopicEntity topic);
        void UpdateTopic(TopicEntity topic);
    }
}
