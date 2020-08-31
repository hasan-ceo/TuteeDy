using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wps.Domain.Concrete;
using Wps.Domain.Entities;
using Wps.WebUI.Models;

namespace Wps.WebUI.Controllers
{
    [Authorize]
    public class WordsController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: Words
        public ActionResult Index()
        {
            var words = db.Words.Include(w => w.Category);
            return View(words.ToList());
        }

        [AllowAnonymous]
        public ActionResult list(string id = "Clothing")
        {
            Category category = db.Categories.Find(id);
            var CategoryName = category.CategoryName;
            ViewBag.titlefull = "http://www.wordpowerswahili.org/words/list/"+id;
            ViewBag.CategoryIDs = "/images/" + id + ".png";
            ViewBag.CategoryName = CategoryName;
            var words = db.Words.Include(w => w.Category).Where(w => w.CategoryID == id).OrderBy(w => w.WordID);

            var cat = db.Categories.OrderBy(c => c.CategoryID);

            WordViewModel viewModel = new WordViewModel
            {
                Categories = cat.ToList(),
                tmpWords = words

            };
            if (viewModel != null)
            {
                return View(viewModel);
            }
            else
                return View();

           
        }


        //public ActionResult Search(string id = "Clothing")
        //{
        //    Category category = db.Categories.Find(id);
        //    var CategoryName = category.CategoryName;
        //    ViewBag.CategoryIDs = "/images/" + id + ".png";
        //    ViewBag.CategoryName = CategoryName;
        //    var words = db.Words.Include(w => w.Category).Where(w => w.CategoryID == id);
        //    return View(words.ToList());
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Search(string SearchString, string SearchButton)
        {
            var cat = db.Categories.OrderBy(c => c.CategoryID).ToList();
            if (SearchString != null && SearchString!="")
            {
                switch (SearchButton)
                {
                    case "Swahili":
                        var wordSwahili = db.Words.Include(w => w.Category).Where(w => w.English.Contains(SearchString));
                        ViewBag.Mcount = wordSwahili.Count();

                        WordViewModel viewModel = new WordViewModel
                        {
                            Categories = cat,
                            tmpWords = wordSwahili

                        };
                        if (viewModel != null)
                        {
                            return View(viewModel);
                        }
                        else
                            return View();

                    case "English":
                        var wordEnglish = db.Words.Include(w => w.Category).Where(w => w.Swahili.Contains(SearchString));
                        ViewBag.Mcount = wordEnglish.Count();
                        

                        WordViewModel viewModelE = new WordViewModel
                        {
                            Categories = cat,
                            tmpWords = wordEnglish

                        };
                        if (viewModelE != null)
                        {
                            return View(viewModelE);
                        }
                        else
                            return View();

                    default:
                        throw new Exception();
                       
                }
                
                
            }
            else
            {
                WordViewModel viewModelx = new WordViewModel
                {
                    Categories = cat,
                    tmpWords = null

                };
                if (viewModelx != null)
                {
                    return View(viewModelx);
                }
                else
                    return View();
            }
            
        }

        // GET: Words/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Word word = db.Words.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        // GET: Words/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Words/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WordID,English,Swahili,CategoryID,Sound")] Word word)
        {
            if (ModelState.IsValid)
            {
                db.Words.Add(word);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", word.CategoryID);
            return View(word);
        }

        // GET: Words/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Word word = db.Words.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", word.CategoryID);
            return View(word);
        }

        // POST: Words/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WordID,English,Swahili,CategoryID,Sound")] Word word)
        {
            if (ModelState.IsValid)
            {
                db.Entry(word).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", word.CategoryID);
            return View(word);
        }

        // GET: Words/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Word word = db.Words.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        // POST: Words/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Word word = db.Words.Find(id);
            db.Words.Remove(word);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
