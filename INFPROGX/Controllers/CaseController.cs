﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INFPROGX.Models;
using INFPROGX.ServiceAccessObjects;

namespace INFPROGX.Controllers
{
    public class CaseController : Controller
    {
        private ShopDbContext db = new ShopDbContext();
        ProductManager pm;
        //
        // GET: /Case/

        public ActionResult Index()
        {
            pm = new ProductManager();
            return View(pm.findAllProducts<Case>());
        }

        //
        // GET: /Case/Details/5

        public ActionResult Details(int id = 0)
        {
            Case Case = (Case)pm.findProductById(id);
            if (Case == null)
            {
                return HttpNotFound();
            }
            return View(Case);
        }

        //
        // GET: /Case/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Case/Create

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Case Case)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(Case);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Case);
        }

        //
        // GET: /Case/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            Case Case = (Case)db.Product.Find(id);
            if (Case == null)
            {
                return HttpNotFound();
            }
            return View(Case);
        }

        //
        // POST: /Case/Edit/5

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Case Case)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Case).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Case);
        }

        //
        // GET: /Case/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id = 0)
        {
            Case Case = (Case)db.Product.Find(id);
            if (Case == null)
            {
                return HttpNotFound();
            }
            return View(Case);
        }

        //
        // POST: /Case/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Case Case = (Case)db.Product.Find(id);
            db.Product.Remove(Case);
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