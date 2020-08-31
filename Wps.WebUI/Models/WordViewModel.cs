using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wps.Domain.Entities;

namespace Wps.WebUI.Models
{
    public class WordViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Word> tmpWords { get; set; }
        public WordUser WordUser { get; set; }


    }
}