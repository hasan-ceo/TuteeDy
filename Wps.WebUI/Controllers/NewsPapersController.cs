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

namespace Wps.WebUI.Controllers
{
    [Authorize]
    public class NewsPapersController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: NewsPapers
        public ActionResult Index()
        {
            return View(db.NewsPapers.ToList());
        }

        [AllowAnonymous]
        public ActionResult list()
        {
            return View(db.NewsPapers.ToList());
        }

        // GET: NewsPapers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsPaper newsPaper = db.NewsPapers.Find(id);
            if (newsPaper == null)
            {
                return HttpNotFound();
            }
            return View(newsPaper);
        }

        // GET: NewsPapers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsPapers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsPaperID,Title,SiteLink")] NewsPaper newsPaper)
        {
            if (ModelState.IsValid)
            {
                db.NewsPapers.Add(newsPaper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsPaper);
        }

        // GET: NewsPapers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsPaper newsPaper = db.NewsPapers.Find(id);
            if (newsPaper == null)
            {
                return HttpNotFound();
            }
            return View(newsPaper);
        }

        // POST: NewsPapers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsPaperID,Title,SiteLink")] NewsPaper newsPaper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsPaper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsPaper);
        }

        // GET: NewsPapers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsPaper newsPaper = db.NewsPapers.Find(id);
            if (newsPaper == null)
            {
                return HttpNotFound();
            }
            return View(newsPaper);
        }

        // POST: NewsPapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsPaper newsPaper = db.NewsPapers.Find(id);
            db.NewsPapers.Remove(newsPaper);
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
