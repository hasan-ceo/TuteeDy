using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Wps.Domain.Entities
{
    public class Newsletter
    {
        [HiddenInput(DisplayValue = false)]
        public int NewsletterID { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Please enter your email.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}
