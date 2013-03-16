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
    public class MoboController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        //
        // GET: /Mobo/

        public ActionResult Index()
        {
            return View(db.Product.ToList().OfType<Mobo>());
        }

        //
        // GET: /Mobo/Details/5

        public ActionResult Details(int id = 0)
        {
            Mobo mobo = (Mobo)db.Product.Find(id);
            if (mobo == null)
            {
                return HttpNotFound();
            }
            return View(mobo);
        }

        //
        // GET: /Mobo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Mobo/Create

        [HttpPost]
        public ActionResult Create(Mobo mobo)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(mobo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mobo);
        }

        //
        // GET: /Mobo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Mobo mobo = (Mobo)db.Product.Find(id);
            if (mobo == null)
            {
                return HttpNotFound();
            }
            return View(mobo);
        }

        //
        // POST: /Mobo/Edit/5

        [HttpPost]
        public ActionResult Edit(Mobo mobo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mobo);
        }

        //
        // GET: /Mobo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Mobo mobo = (Mobo)db.Product.Find(id);
            if (mobo == null)
            {
                return HttpNotFound();
            }
            return View(mobo);
        }

        //
        // POST: /Mobo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Mobo mobo = (Mobo)db.Product.Find(id);
            db.Product.Remove(mobo);
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