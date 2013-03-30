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
        private ShopDbContext db = new ShopDbContext();

        //
        // GET: /Harddisk/

        public ActionResult Index()
        {
            return View(db.Product.ToList().OfType<Harddisk>());
        }

        //
        // GET: /Harddisk/Details/5

        public ActionResult Details(int id = 0)
        {
            Harddisk harddisk = (Harddisk)db.Product.Find(id);
            if (harddisk == null)
            {
                return HttpNotFound();
            }
            return View(harddisk);
        }

        //
        // GET: /Harddisk/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Harddisk/Create

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Harddisk harddisk)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(harddisk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(harddisk);
        }

        //
        // GET: /Harddisk/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            Harddisk harddisk = (Harddisk)db.Product.Find(id);
            if (harddisk == null)
            {
                return HttpNotFound();
            }
            return View(harddisk);
        }

        //
        // POST: /Harddisk/Edit/5

        [HttpPost]
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id = 0)
        {
            Harddisk harddisk = (Harddisk)db.Product.Find(id);
            if (harddisk == null)
            {
                return HttpNotFound();
            }
            return View(harddisk);
        }

        //
        // POST: /Harddisk/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Harddisk harddisk = (Harddisk)db.Product.Find(id);
            db.Product.Remove(harddisk);
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