using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPresentationLayer.Models
{
    public class Post
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public int UserId { get; set; }

        [DataType(DataType.MultilineText)]
        [UIHint("MultilineText")]
        [Required(ErrorMessage = "You can't add empty message.")]
        [StringLength(4000, ErrorMessage = "Message can't contain more than 4000 characters")]
        public string Text { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Date { get; set; }

        [ScaffoldColumn(false)]
        public int TopicId { get; set; }

        public Topic Topic { get; set; }
        public User User { get; set; }
    }
}