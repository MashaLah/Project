using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy hh:mm}")]
        public DateTime Date { get; set; }

        [ScaffoldColumn(false)]
        public int TopicId { get; set; }

        [ScaffoldColumn(false)]
        public int StateId { get; set; }

        public Topic Topic { get; set; }
        public User User { get; set; }
        public State State { get; set; }
    }
}