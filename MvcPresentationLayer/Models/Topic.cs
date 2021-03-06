﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPresentationLayer.Models
{
    public class Topic
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title can not be empty.")]
        [Display(Name = "Title of topic")]
        [StringLength(250, ErrorMessage = "Title can't contain more than 250 characters")]
        public string Title { get; set; }

        [Display(Name = "Description of topic")]
        [StringLength(4000, ErrorMessage = "Descriptin is too long")]
        public string Description { get; set; }

        [ScaffoldColumn(false)]
        public int UserId { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy at HH:mm}")]
        public DateTime Date { get; set; }

        [ScaffoldColumn(false)]
        public int ForumId { get; set; }

        [ScaffoldColumn(false)]
        public int StateId { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy HH:mm}")]
        public DateTime? LastUpdatedDate { get; set; }

        public Forum Forum { get; set; }
        public User User { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}