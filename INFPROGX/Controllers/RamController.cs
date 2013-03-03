﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INFPROGX.Models;

namespace INFPROGX.Controllers
{
    public class RamController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        //
        // GET: /Ram/

        public ActionResult Index()
        {
            return View(db.Ram.ToList());
        }

        //
        // GET: /Ram/Details/5

        public ActionResult Details(int id = 0)
        {
            Ram ram = db.Ram.Find(id);
            if (ram == null)
            {
                return HttpNotFound();
            }
            return View(ram);
        }

        //
        // GET: /Ram/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Ram/Create

        [HttpPost]
        public ActionResult Create(Ram ram)
        {
            if (ModelState.IsValid)
            {
                db.Ram.Add(ram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ram);
        }

        //
        // GET: /Ram/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ram ram = db.Ram.Find(id);
            if (ram == null)
            {
                return HttpNotFound();
            }
            return View(ram);
        }

        //
        // POST: /Ram/Edit/5

        [HttpPost]
        public ActionResult Edit(Ram ram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ram);
        }

        //
        // GET: /Ram/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ram ram = db.Ram.Find(id);
            if (ram == null)
            {
                return HttpNotFound();
            }
            return View(ram);
        }

        //
        // POST: /Ram/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Ram ram = db.Ram.Find(id);
            db.Ram.Remove(ram);
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