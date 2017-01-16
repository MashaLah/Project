using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IForumService
    {
        ForumEntity GetForumEntity(int id);
        IEnumerable<ForumEntity> GetAllForumEntities();
        IEnumerable<ForumEntity> GetAllForumEntitiesByParentId(int id);
        IEnumerable<ForumEntity> GetForumsByPredicate(Expression<Func<ForumEntity, bool>> f);
        void CreateForum(ForumEntity forum);
        void DeleteForum(ForumEntity forum);
        void UpdateForum(ForumEntity forum);
    }
}
