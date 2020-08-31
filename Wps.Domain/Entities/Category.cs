using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Wps.Domain.Entities
{
    public class Category
    {
        [Key]
        [Display(Name = "ID")]
        public string CategoryID { get; set; }

        [Display(Name = "Category")]
        [MaxLength(50)]
        public string CategoryName { get; set; }

    }
}
