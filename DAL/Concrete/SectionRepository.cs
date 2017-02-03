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
            var allSections = context.Set<Section>().Include(s => s.Forums);
            List<DALSection> sections = new List<DALSection>();
            foreach (var section in allSections)
            {
                sections.Add(section.ToDalSection());
            }
            return sections;
        }

        public DALSection GetById(int key)
        {
            return context.Set<Section>().FirstOrDefault(section => section.Id == key).ToDalSection();           
        }

        public void Create(DALSection e)
        {
            /*var section = new Section()
            {
                Name = e.Name,
            };*/
            context.Set<Section>().Add(e.ToOrmSection());
        }

        public void Delete(DALSection e)
        {
            /*var section = new Section()
            {
                Id = e.Id,
                Name = e.Name,
            };*/
            var section = context.Set<Section>().Single(s => s.Id == e.Id);
            context.Set<Section>().Remove(section);
        }

        public void Update(DALSection entity)
        {
            var section = context.Set<Section>().Single(s => s.Id == entity.Id);
            section.Name = entity.Name;
        }
    }
}
