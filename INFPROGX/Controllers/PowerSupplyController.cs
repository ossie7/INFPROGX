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
    public class PowerSupplyController : Controller
    {
        private PowerSupplyDBContext db = new PowerSupplyDBContext();

        //
        // GET: /PowerSupply/

        public ActionResult Index()
        {
            return View(db.PowerSupply.ToList());
        }

        //
        // GET: /PowerSupply/Details/5

        public ActionResult Details(int id = 0)
        {
            PowerSupply powersupply = db.PowerSupply.Find(id);
            if (powersupply == null)
            {
                return HttpNotFound();
            }
            return View(powersupply);
        }

        //
        // GET: /PowerSupply/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PowerSupply/Create

        [HttpPost]
        public ActionResult Create(PowerSupply powersupply)
        {
            if (ModelState.IsValid)
            {
                db.PowerSupply.Add(powersupply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(powersupply);
        }

        //
        // GET: /PowerSupply/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PowerSupply powersupply = db.PowerSupply.Find(id);
            if (powersupply == null)
            {
                return HttpNotFound();
            }
            return View(powersupply);
        }

        //
        // POST: /PowerSupply/Edit/5

        [HttpPost]
        public ActionResult Edit(PowerSupply powersupply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(powersupply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(powersupply);
        }

        //
        // GET: /PowerSupply/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PowerSupply powersupply = db.PowerSupply.Find(id);
            if (powersupply == null)
            {
                return HttpNotFound();
            }
            return View(powersupply);
        }

        //
        // POST: /PowerSupply/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PowerSupply powersupply = db.PowerSupply.Find(id);
            db.PowerSupply.Remove(powersupply);
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