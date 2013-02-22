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
    public class CaseController : Controller
    {
        private CaseDbContext db = new CaseDbContext();

        //
        // GET: /Case/

        public ActionResult Index()
        {
            return View(db.Case.ToList());
        }

        //
        // GET: /Case/Details/5

        public ActionResult Details(int id = 0)
        {
            Case Case = db.Case.Find(id);
            if (Case == null)
            {
                return HttpNotFound();
            }
            return View(Case);
        }

        //
        // GET: /Case/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Case/Create

        [HttpPost]
        public ActionResult Create(Case Case)
        {
            if (ModelState.IsValid)
            {
                db.Case.Add(Case);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Case);
        }

        //
        // GET: /Case/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Case Case = db.Case.Find(id);
            if (Case == null)
            {
                return HttpNotFound();
            }
            return View(Case);
        }

        //
        // POST: /Case/Edit/5

        [HttpPost]
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

        public ActionResult Delete(int id = 0)
        {
            Case Case = db.Case.Find(id);
            if (Case == null)
            {
                return HttpNotFound();
            }
            return View(Case);
        }

        //
        // POST: /Case/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Case Case = db.Case.Find(id);
            db.Case.Remove(Case);
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