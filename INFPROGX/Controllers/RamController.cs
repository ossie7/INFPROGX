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
            var product = db.Product.ToList();
            //return View(product);
            return View(db.Product.ToList().OfType<Ram>());
        }

        //
        // GET: /Ram/Details/5

        public ActionResult Details(int id = 0)
        {
            Ram ram = (Ram)db.Product.Find(id);
            if (ram == null)
            {
                return HttpNotFound();
            }
            return View(ram);
        }

        //
        // GET: /Ram/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Ram/Create

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Ram ram)
        {
            if (ModelState.IsValid)
            {
                ram.Price = (float)Math.Round(ram.Price / 100, 2);
                db.Product.Add(ram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ram);
        }

        //
        // GET: /Ram/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            Ram ram = (Ram)db.Product.Find(id);
            if (ram == null)
            {
                return HttpNotFound();
            }
            return View(ram);
        }

        //
        // POST: /Ram/Edit/5

        [HttpPost]
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id = 0)
        {
            Ram ram = (Ram)db.Product.Find(id);
            if (ram == null)
            {
                return HttpNotFound();
            }
            return View(ram);
        }

        //
        // POST: /Ram/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Ram ram = (Ram)db.Product.Find(id);
            db.Product.Remove(ram);
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