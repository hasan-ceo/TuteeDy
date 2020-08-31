using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Wps.Domain.Entities
{
    public class NewsPaper
    {
        [HiddenInput(DisplayValue = false)]
        public int NewsPaperID { get; set; }

        [Required(ErrorMessage = "Please enter a Title")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a Site Link")]
        [Display(Name = "Site Link")]
        public string SiteLink { get; set; }

    }
}
