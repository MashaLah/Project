using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPresentationLayer.Models
{
    public class ProfileViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Login can not be empty")]
        [Display(Name = "Login")]
        [RegularExpression(@"(^[a-zA-Z0-9\s]*$)", ErrorMessage ="Can contain only letters and digits.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Login must contain from 2 to 50 characters")]
        public string Login { get; set; }

        [ScaffoldColumn(false)]
        public DateTime LastUpdateDate { get; set; }

        [ScaffoldColumn(false)]
        public int UserId { get; set; }

        public byte[] Image { get; set; }

        [ScaffoldColumn(false)]
        public string ImageMimeType { get; set; }
    }
}