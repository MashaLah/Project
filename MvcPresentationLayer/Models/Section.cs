using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPresentationLayer.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Topic> Topics { get; set; }
    }
}