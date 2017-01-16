using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPresentationLayer.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public System.DateTime Date { get; set; }

        public Section Section { get; set; }
       // public virtual User User { get; set; }
        public ICollection<Topic> Topics { get; set; }

    }
}