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
    public class ForumRepository : IForumRepository
    {
        private readonly DbContext context;

        public ForumRepository(DbContext uow)
        {
            context = uow;
        }

        public IEnumerable<DALForum> GetAll()
        {
            return context.Set<Forum>().Select(forum => new DALForum()
            {
                Id = forum.Id,
                SectionId = forum.SectionId,
                Title = forum.Title,
                UserId = forum.UserId,
                Date = forum.Date
            });
        }

        public DALForum GetById(int key)
        {
            var ormForum = context.Set<Forum>().FirstOrDefault(forum => forum.Id == key);
            return new DALForum()
            {
                Id = ormForum.Id,
                SectionId = ormForum.SectionId,
                Title = ormForum.Title,
                UserId = ormForum.UserId,
                Date = ormForum.Date
            };
        }

        public IEnumerable<DALForum> GetByParentId(int key)
        {
            return context.Set<Forum>().Where(f=>f.SectionId==key).Select(forum => new DALForum()
            {
                Id = forum.Id,
                SectionId = forum.SectionId,
                Title = forum.Title,
                UserId = forum.UserId,
                Date = forum.Date
            });
        }

        /*public IEnumerable<DALForum> GetByPredicate(Expression<Func<DALForum, bool>> f)
        {
            //Expression<Func<DalUser, bool>> -> Expression<Func<User, bool>> (!)
            // throw new NotImplementedException();
            //var forums = context.Set<Forum>().All(f);
        }*/

        public void Create(DALForum e)
        {
            //проверить, сущ. ли sectionId
            var forum = new Forum()
            {
                SectionId = e.SectionId,
                //SectionId = sectionId,
                Title = e.Title,
                UserId = e.UserId,
               // UserId = 2,
                Date = e.Date
                //Date = DateTime.Now
            };
            context.Set<Forum>().Add(forum);
        }

        public void Delete(DALForum f)
        {
            var forum = new Forum()
            {
                Id = f.Id,
                SectionId = f.SectionId,
                Title = f.Title,
                UserId = f.UserId,
                Date = f.Date
            };
            forum = context.Set<Forum>().FirstOrDefault(frm => frm.Id == forum.Id);
            context.Set<Forum>().Remove(forum);
        }

        public void Update(DALForum f)
        {
            var forum = context.Set<Forum>().FirstOrDefault(frm => frm.Id == f.Id);

            //forum.Id = f.Id;
            forum.SectionId = f.SectionId;
            forum.Title = f.Title;
            forum.UserId = f.UserId;
            forum.Date = f.Date;
        }

    }
}
