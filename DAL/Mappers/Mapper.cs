using DAL.Interface.DTO;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class Mapper
    {
        public static DALSection ToDalSection(this Section ormSection)
        {
            DALSection dalSection = new DALSection()
            {
                Id = ormSection.Id,
                Name = ormSection.Name,
                //Forums = new List<DALForum>()
            };

            /*var forums = ormSection.Forums.Select(forum => new DALForum()
            {
                Id = forum.Id,
                SectionId = forum.SectionId,
                Title = forum.Title,
                UserId = forum.UserId,
                Date = forum.Date,
            });

            foreach (var forum in forums)
            {
                dalSection.Forums.Add(forum);
            }*/
            return dalSection;
        }

        public static Section ToOrmSection(this DALSection dalSection)
        {
            Section section = new Section()
            {
                Id = dalSection.Id,
                Name = dalSection.Name
            };

            /*var forums = dalSection.Forums.Select(forum => new Forum()
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
            return section;
        }
    }
}
