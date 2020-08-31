using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wps.Domain.Entities;

namespace Wps.WebUI.Models
{
    public class WordUsersViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<WordUser> tmpWords { get; set; }

    }
}