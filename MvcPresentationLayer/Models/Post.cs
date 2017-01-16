using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPresentationLayer.Models
{
    public class Post
    {
        public int Id { get; set; }
        //public int UserId { get; set; }
        public string Text { get; set; }
        public System.DateTime Date { get; set; }
        public int TopicId { get; set; }

        public Topic Topic { get; set; }
       // public virtual User User { get; set; }
    }
}