using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPresentationLayer.Models
{
    public class User
    {
        [Display(Name = "User's e-mail")]
        public string Email { get; set; }

        [Display(Name = "Date of user's registration")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "User's role in the system")]
        public string Role { get; set; }

        public ProfileViewModel Profile { get; set; }
    }
}