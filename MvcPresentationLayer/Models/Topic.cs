using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPresentationLayer.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       // public int UserId { get; set; }
        public System.DateTime Date { get; set; }
        public int ForumId { get; set; }

        public Forum Forum { get; set; }
        public ICollection<Post> Posts { get; set; }
        //public virtual User User { get; set; }
    }
}