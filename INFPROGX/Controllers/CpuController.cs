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
    public class CpuController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        //
        // GET: /Cpu/

        public ActionResult Index()
        {
            return View(db.Product.ToList().OfType<Cpu>());
        }

        //
        // GET: /Cpu/Details/5

        public ActionResult Details(int id = 0)
        {
            Cpu cpu = (Cpu)db.Product.Find(id);
            if (cpu == null)
            {
                return HttpNotFound();
            }
            return View(cpu);
        }

        //
        // GET: /Cpu/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cpu/Create

        [HttpPost]
        public ActionResult Create(Cpu cpu)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(cpu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cpu);
        }

        //
        // GET: /Cpu/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cpu cpu = (Cpu)db.Product.Find(id);
            if (cpu == null)
            {
                return HttpNotFound();
            }
            return View(cpu);
        }

        //
        // POST: /Cpu/Edit/5

        [HttpPost]
        public ActionResult Edit(Cpu cpu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cpu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cpu);
        }

        //
        // GET: /Cpu/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cpu cpu = (Cpu)db.Product.Find(id);
            if (cpu == null)
            {
                return HttpNotFound();
            }
            return View(cpu);
        }

        //
        // POST: /Cpu/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cpu cpu = (Cpu)db.Product.Find(id);
            db.Product.Remove(cpu);
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