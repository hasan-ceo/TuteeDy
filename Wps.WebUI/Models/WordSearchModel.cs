using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wps.Domain.Entities;

namespace Wps.WebUI.Models
{
    public class WordSearchModel
    {
        [Display(Name = "Word")]
        public string Word { get; set; }
    }
}
