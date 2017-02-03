using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class ForumRepository:IForumRepository
    {
        private readonly DbContext context;

        public ForumRepository(DbContext uow)
        {
            context = uow;
        }

        public IEnumerable<DALForum> GetAll()
        {
            var allForums = context.Set<Forum>().Include(s => s.Topics);
            List<DALForum> forums = new List<DALForum>();
            foreach (var forum in allForums)
            {
                forums.Add(forum.ToDalForum());
            }
            return forums;
        }

        public DALForum GetById(int key)
        {
            return context.Set<Forum>().FirstOrDefault(section => section.Id == key).ToDalForum();
        }

        public void Create(DALForum e)
        {
            /*var forum = new Forum()
            {
                Title = e.Title,
                Description=e.Description,
                SectionId=e.SectionId,
                LastUpdatedDate=e.LastUpdatedDate,
            };*/
            context.Set<Forum>().Add(e.ToOrmForum());
        }

        public void Delete(DALForum e)
        {
            /*Forum forum = new Forum()
            {
                Id = e.Id,
                Title = e.Title,
                Description=e.Description,
                LastUpdatedDate=e.LastUpdatedDate,
                SectionId=e.SectionId
            };*/
            var forum = context.Set<Forum>().Single(s => s.Id == e.Id);
            context.Set<Forum>().Remove(forum);
        }

        public void Update(DALForum entity)
        {
            Forum forum = context.Set<Forum>().Single(s => s.Id == entity.Id);
            forum.Title = entity.Title;
            forum.Description = entity.Description;
            forum.SectionId = entity.SectionId;
        }
    }
}
