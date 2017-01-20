using DAL.Concrete;
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
    public class SectionRepository : ISectionRepository 
    {
        private readonly DbContext context;

        public SectionRepository(DbContext uow)
        {
            context = uow;
        }

        public IEnumerable<DALSection> GetAll()
        {
             //var allSections = context.Set<Section>().Select(section => section.ToDalSection);           {
             /*    Id = section.Id,
                 Name = section.Name,
             });
             IEnumerable<DALSection> sects = new List<DALSection>();
             foreach (var item in allSections)
             {
                 sects.Add(item);
             }*/
            /*var allSections = context.Set<Section>().Include(s => s.Forums);
            List<DALSection> sections = new List<DALSection>();
            foreach (var section in allSections)
            {
                sections.Add(section.ToDalSection());
            }
            return sections;*/
            return context.Set<Section>().Select(section => new DALSection()
            {
                Id=section.Id,
                Name=section.Name
            });
        }

        /*public DALForum toDalForum(Forum forum)
        {
            return new DALForum()
            {
                Id = forum.Id,
                SectionId = forum.SectionId,
                Title = forum.Title,
                UserId = forum.UserId,
                Date = forum.Date,
            };
        }*/

        public DALSection GetById(int key)
        {
            return context.Set<Section>().FirstOrDefault(section => section.Id == key).ToDalSection();           
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
            /*var forums = e.Forums.Select(forum => new Forum()
            {
                Id = forum.Id,
                SectionId = forum.SectionId,
                Title = forum.Title,
                UserId = forum.UserId,
                Date = forum.Date,
            });
            foreach (var forum in forums)
            {
                section.Forums.Add(forum);
            }*/
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
            var section = context.Set<Section>().Single(s => s.Id == entity.Id);
            section.Name = entity.Name;
            context.Entry(section).State = EntityState.Modified;
            /*var forums = entity.Forums.Select(forum => new Forum()
            {
                Id = forum.Id,
                SectionId = forum.SectionId,
                Title = forum.Title,
                UserId = forum.UserId,
                Date = forum.Date,
            });
            foreach (var forum in forums)
            {
                section.Forums.Add(forum);
            }*/
        }
    }
}
