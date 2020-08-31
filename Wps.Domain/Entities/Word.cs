using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Wps.Domain.Entities
{
    public class Word
    {
        [HiddenInput(DisplayValue = false)]
        public int WordID { get; set; }

        [Required(ErrorMessage = "Please enter a English Word")]
        [Display(Name = "English")]
        public string English { get; set; }

        [Required(ErrorMessage = "Please enter a Swahili Word")]
        [Display(Name = "Swahili")]
        public string Swahili { get; set; }

        [Display(Name = "Category")]
        public string CategoryID { get; set; }

        public virtual Category Category { get; set; }

        [Required(ErrorMessage = "Please enter a Sound")]
        [Display(Name = "Sound")]
        public string Sound { get; set; }

    }
}
