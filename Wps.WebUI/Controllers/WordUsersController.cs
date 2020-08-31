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
    public class WordUsersController : Controller
    {
        private EFDbContext db = new EFDbContext();
        private string catId = "";

        // GET: WordUsers
        public ActionResult Index(string catId = "AdditionOfw")
        {
            var cat = db.Categories.OrderBy(c => c.CategoryID);
            var wordusers = db.WordUsers.OrderBy(c => c.CategoryID).ThenBy(c => c.English);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", catId);

            WordUsersViewModel viewModel = new WordUsersViewModel
            {
                Categories = cat.ToList(),
                tmpWords = wordusers.ToList()

            };
            if (viewModel != null)
            {
                return View(viewModel);
            }
            else
                return View();
        }


        // GET: WordUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordUser wordUser = db.WordUsers.Find(id);
            if (wordUser == null)
            {
                return HttpNotFound();
            }
            return View(wordUser);
        }

        // GET: WordUsers/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: WordUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WordUserID,English,Swahili,CategoryID,Acknowledge")] WordUser wordUser)
        {
            if (ModelState.IsValid)
            {
                db.WordUsers.Add(wordUser);
                db.SaveChanges();

                ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", wordUser.CategoryID);
                return RedirectToAction("Index", new { catId = wordUser.CategoryID });
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", wordUser.CategoryID);
            return View(wordUser);
        }

        // GET: WordUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordUser wordUser = db.WordUsers.Find(id);
            if (wordUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", wordUser.CategoryID);
            return View(wordUser);
        }

        // POST: WordUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WordUserID,English,Swahili,CategoryID,Acknowledge")] WordUser wordUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wordUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", wordUser.CategoryID);
            return View(wordUser);
        }

        // GET: WordUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordUser wordUser = db.WordUsers.Find(id);
            if (wordUser == null)
            {
                return HttpNotFound();
            }
            return View(wordUser);
        }

        // POST: WordUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WordUser wordUser = db.WordUsers.Find(id);
            db.WordUsers.Remove(wordUser);
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
