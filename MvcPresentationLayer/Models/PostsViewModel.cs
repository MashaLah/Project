using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPresentationLayer.Models
{
    public class PostsViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
       // public Topic Topic { get; set; }
       // public int NumberOfPosts { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}