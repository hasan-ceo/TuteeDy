using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Wps.Domain.Entities
{
    public class SyllableSounds
    {
        [HiddenInput(DisplayValue = false)]
        public string SyllableSoundsId { get; set; }

        [Display(Name = "Cons")]
        public string Cons { get; set; }

        [Display(Name = "A")]
        public string A { get; set; }

        [Display(Name = "E")]
        public string E { get; set; }

        [Display(Name = "I")]
        public string I { get; set; }

        [Display(Name = "O")]
        public string O { get; set; }

        [Display(Name = "U")]
        public string U { get; set; }

        [Display(Name = "SType")]
        public int SType { get; set; }

        
    }
}
