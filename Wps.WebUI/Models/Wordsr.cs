using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Wps.Domain.Entities;

namespace Wps.WebUI.Models
{
    //[Serializable]
    public class Wordsr
    {
        //[XmlElement("WordID")]
        public int WordID { get; set; }

        //[XmlElement("English")]
        public string English { get; set; }

        //[XmlElement("Swahili")]
        public string Swahili { get; set; }

        //[XmlElement("CategoryID")]
        public string CategoryID { get; set; }

        //[XmlElement("Sound")]
        public string Sound { get; set; }

    }
}
