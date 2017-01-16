using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DALForum : IEntity 
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }

    }
}
