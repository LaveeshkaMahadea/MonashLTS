using System;
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
    public class TeachingAssistantsController : Controller
    {
        private LTS db = new LTS();

        // GET: TeachingAssistants
        public ActionResult Index()
        {
            return View(db.TeachingAssistants.ToList());
        }

        // GET: TeachingAssistants/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeachingAssistant teachingAssistant = db.TeachingAssistants.Find(id);
            if (teachingAssistant == null)
            {
                return HttpNotFound();
            }
            return View(teachingAssistant);
        }

        // GET: TeachingAssistants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeachingAssistants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FirstNameTA,LastNameTA")] TeachingAssistant teachingAssistant)
        {
            if (ModelState.IsValid)
            {
                db.TeachingAssistants.Add(teachingAssistant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teachingAssistant);
        }

        // GET: TeachingAssistants/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeachingAssistant teachingAssistant = db.TeachingAssistants.Find(id);
            if (teachingAssistant == null)
            {
                return HttpNotFound();
            }
            return View(teachingAssistant);
        }

        // POST: TeachingAssistants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FirstNameTA,LastNameTA")] TeachingAssistant teachingAssistant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teachingAssistant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teachingAssistant);
        }

        // GET: TeachingAssistants/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeachingAssistant teachingAssistant = db.TeachingAssistants.Find(id);
            if (teachingAssistant == null)
            {
                return HttpNotFound();
            }
            return View(teachingAssistant);
        }

        // POST: TeachingAssistants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TeachingAssistant teachingAssistant = db.TeachingAssistants.Find(id);
            db.TeachingAssistants.Remove(teachingAssistant);
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
