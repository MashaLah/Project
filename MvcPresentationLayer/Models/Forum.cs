using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPresentationLayer.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public int SectionId { get; set; }
        public ICollection<Topic> Topics { get; set; }
    }
}