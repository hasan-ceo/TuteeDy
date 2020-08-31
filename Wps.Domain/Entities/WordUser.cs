using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Wps.Domain.Entities
{
    public class WordUser
    {
        [HiddenInput(DisplayValue = false)]
        public int WordUserID { get; set; }

        [Required(ErrorMessage = "Please enter a English Word (*)")]
        [Display(Name = "English")]
        public string English { get; set; }

        [Required(ErrorMessage = "Please enter a Swahili Word (*)")]
        [Display(Name = "Swahili")]
        public string Swahili { get; set; }

        [Display(Name = "Suggested Category")]
        public string CategoryID { get; set; }

        public virtual Category Category { get; set; }

        [Display(Name = "Please enter your name.")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Please enter your email.")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Please enter a Sound")]
        //[Display(Name = "Sound")]
        //public string Sound { get; set; }

        //public bool Acknowledge { get; set; }

    }
}
