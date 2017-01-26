using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DALTopic : IEntity 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        //public int ForumId { get; set; }
        public int SectionId { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public ICollection<DALPost> Posts { get; set; }
        public DALUser User { get; set; }
    }
}
