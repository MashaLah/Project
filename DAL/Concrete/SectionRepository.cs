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
    public class SectionRepository : ISectionRepository 
    {
        private readonly DbContext context;

        public SectionRepository(DbContext uow)
        {
            context = uow;
        }

        public IEnumerable<DALSection> GetAll()
        {
            return context.Set<Section>().Select(section => new DALSection()
            {
                Id = section.Id,
                Name = section.Name,
            });
        }

        public DALSection GetById(int key)
        {
            var ormForum = context.Set<Section>().FirstOrDefault(section => section.Id == key);
            return new DALSection()
            {
                Id = ormForum.Id,
                Name = ormForum.Name,
            };
        }

       /* public IEnumerable<DALSection> GetByPredicate(Expression<Func<DALSection, bool>> f)
        {
            //Expression<Func<DalUser, bool>> -> Expression<Func<User, bool>> (!)
            throw new NotImplementedException();
        }*/

        public void Create(DALSection e)
        {
            var section = new Section()
            {
                Name = e.Name,
            };
            context.Set<Section>().Add(section);
        }

        public void Delete(DALSection e)
        {
            var section = new Section()
            {
                Id = e.Id,
                Name = e.Name,
            };
            section = context.Set<Section>().Single(s => s.Id == section.Id);
            context.Set<Section>().Remove(section);
        }

        public void Update(DALSection entity)
        {
            var post = context.Set<Section>().Single(s => s.Id == entity.Id);
            post.Name = entity.Name;
        }
    }
}
