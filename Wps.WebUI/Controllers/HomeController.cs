using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Wps.Domain.Abstract;
using Wps.Domain.Concrete;
using Wps.WebUI.Models;

namespace Wps.WebUI.Controllers
{

    public class HomeController : Controller
    {

        private EFDbContext db = new EFDbContext();

        public ActionResult Index()
        {
            var cat = db.Categories.OrderBy(c=>c.CategoryID);
            //var additionOfw = db.Words.Where(w => w.CategoryID == "AdditionOfw").Take(10);
            //var sameSoundasInEnglish = db.Words.Where(w => w.CategoryID == "SameSoundasInEnglish").Take(10);
            //var twoConsonantCombinations = db.Words.Where(w => w.CategoryID == "TwoConsonantCombinations").Take(10);
            //var verbs = db.Words.Where(w => w.CategoryID == "Verbs").Take(10);

            HomePageView viewModel = new HomePageView
            {
                Categories = cat.ToList(),
                SyllableSounds1= db.SyllableSounds.Where(s => s.SType==1).OrderBy(s => s.SyllableSoundsId).ToList(),
                SyllableSounds2 = db.SyllableSounds.Where(s => s.SType == 2).OrderBy(s => s.SyllableSoundsId).ToList()

            };
            if (viewModel != null)
            {
                return View(viewModel);
            }
            else
                return View();
        }


        public ActionResult Books()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Videos()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Teachers()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Music()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult NewsPaper()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



    }
}