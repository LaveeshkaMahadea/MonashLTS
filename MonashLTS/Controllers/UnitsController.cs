﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MonashLTS.Models;

namespace MonashLTS.Controllers
{
    public class UnitsController : Controller
    {
        private LTS db = new LTS();

        // GET: Units
        public ActionResult Index()
        {
            var units = db.Units.Include(u => u.Student).Include(u => u.TeachingAssistant);
            return View(units.ToList());
        }

        // GET: Units/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: Units/Create
        public ActionResult Create()
        {
            ViewBag.Student_id = new SelectList(db.Students, "id", "AlternateOffering");
            ViewBag.TeachingAssistant_id = new SelectList(db.TeachingAssistants, "id", "FirstNameTA");
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UnitCode,Deliverable,UnitTeachingLeadPrimary,UnitOwningOrgPrimary,UnitLevel,UnitLocation,UnitMode,Eftsl,UnitOfferingYear,UnitOfferingSem,Student_id,TeachingAssistant_id")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Units.Add(unit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Student_id = new SelectList(db.Students, "id", "AlternateOffering", unit.Student_id);
            ViewBag.TeachingAssistant_id = new SelectList(db.TeachingAssistants, "id", "FirstNameTA", unit.TeachingAssistant_id);
            return View(unit);
        }

        // GET: Units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            ViewBag.Student_id = new SelectList(db.Students, "id", "AlternateOffering", unit.Student_id);
            ViewBag.TeachingAssistant_id = new SelectList(db.TeachingAssistants, "id", "FirstNameTA", unit.TeachingAssistant_id);
            return View(unit);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UnitCode,Deliverable,UnitTeachingLeadPrimary,UnitOwningOrgPrimary,UnitLevel,UnitLocation,UnitMode,Eftsl,UnitOfferingYear,UnitOfferingSem,Student_id,TeachingAssistant_id")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Student_id = new SelectList(db.Students, "id", "AlternateOffering", unit.Student_id);
            ViewBag.TeachingAssistant_id = new SelectList(db.TeachingAssistants, "id", "FirstNameTA", unit.TeachingAssistant_id);
            return View(unit);
        }

        // GET: Units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit unit = db.Units.Find(id);
            db.Units.Remove(unit);
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
