using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INFPROGX.Models;

namespace INFPROGX.Controllers
{
    public class HarddiskController : Controller
    {
        private HarddiskDbContext db = new HarddiskDbContext();

        //
        // GET: /Harddisk/

        public ActionResult Index()
        {
            return View(db.Harddisk.ToList());
        }

        //
        // GET: /Harddisk/Details/5

        public ActionResult Details(int id = 0)
        {
            Harddisk harddisk = db.Harddisk.Find(id);
            if (harddisk == null)
            {
                return HttpNotFound();
            }
            return View(harddisk);
        }

        //
        // GET: /Harddisk/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Harddisk/Create

        [HttpPost]
        public ActionResult Create(Harddisk harddisk)
        {
            if (ModelState.IsValid)
            {
                db.Harddisk.Add(harddisk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(harddisk);
        }

        //
        // GET: /Harddisk/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Harddisk harddisk = db.Harddisk.Find(id);
            if (harddisk == null)
            {
                return HttpNotFound();
            }
            return View(harddisk);
        }

        //
        // POST: /Harddisk/Edit/5

        [HttpPost]
        public ActionResult Edit(Harddisk harddisk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(harddisk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(harddisk);
        }

        //
        // GET: /Harddisk/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Harddisk harddisk = db.Harddisk.Find(id);
            if (harddisk == null)
            {
                return HttpNotFound();
            }
            return View(harddisk);
        }

        //
        // POST: /Harddisk/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Harddisk harddisk = db.Harddisk.Find(id);
            db.Harddisk.Remove(harddisk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}