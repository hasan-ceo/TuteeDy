using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wps.Domain.Entities;

namespace Wps.WebUI.Models
{
    public class HomePageView
    {
        public IEnumerable<Category> Categories { get; set; }
        //public IEnumerable<Word> AdditionOfws { get; set; }
        //public IEnumerable<Word> SameSoundasInEnglishs { get; set; }
        //public IEnumerable<Word> TwoConsonantCombinationes { get; set; }
        //public IEnumerable<Word> Verbes { get; set; }
        public IEnumerable<SyllableSounds> SyllableSounds1 { get; set; }
        public IEnumerable<SyllableSounds> SyllableSounds2 { get; set; }
    }
}