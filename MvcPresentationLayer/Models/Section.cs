using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPresentationLayer.Models
{
    public class Section
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Section name can't be empty")]
        [StringLength(250, ErrorMessage = "Message can't contain more than 250 characters")]
        public string Name { get; set; }

        public ICollection<Forum> Forums { get; set; }
    }
}