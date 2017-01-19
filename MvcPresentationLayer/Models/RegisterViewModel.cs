using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPresentationLayer.Models
{
    public class RegisterViewModel
    {           
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Enter your e-mail")]
        [Required(ErrorMessage = "The field can not be empty!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email adress is not correct")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "The password must contain from 6 to 50 characters")]
        //[RegularExpression(@"^(?=.*?[A-Za-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-])$", ErrorMessage ="Password must contail at least one letter, one digit and one spesial character.")]
        [RegularExpression(@"(?=.*[#?!@$%^&*-])(?=.*[0-9])(?=.*[A-Za-z]).*$", ErrorMessage ="Password must contail at least one letter, one digit and one spesial character.")]
        [DataType(DataType.Password)]
        [Display(Name = "Enter your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm the password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm the password")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Enter the code from the image")]
        public string Captcha { get; set; }

        //don't use
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        //don't use
        public string AvatarPath { get; set; }
    }
}