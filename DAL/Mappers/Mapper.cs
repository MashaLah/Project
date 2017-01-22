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
                Topics = new List<DALTopic>()
            };

            var topics = ormSection.Topics.Select(topic => new DALTopic()
            {
                Id = topic.Id,
                SectionId = topic.SectionId,
                Title = topic.Title,
                UserId = topic.UserId,
                Date = topic.Date,
                Description=topic.Description,
                LastUpdatedDate=topic.LastUpdatedDate
            });

            foreach (var topic in topics)
            {
                dalSection.Topics.Add(topic);
            }
            return dalSection;
        }

        public static Section ToOrmSection(this DALSection dalSection)
        {
            Section section = new Section()
            {
                Id = dalSection.Id,
                Name = dalSection.Name
            };

            var topics = dalSection.Topics.Select(topic => new Topic()
            {
                Id = topic.Id,
                SectionId = topic.SectionId,
                Title = topic.Title,
                UserId = topic.UserId,
                Date = topic.Date,
                Description = topic.Description,
                LastUpdatedDate = topic.LastUpdatedDate
            });

            foreach (var topic in topics)
            {
                section.Topics.Add(topic);
            }
            return section;
        }
    }
}
