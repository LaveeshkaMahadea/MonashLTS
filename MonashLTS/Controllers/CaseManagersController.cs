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
    public class CaseManagersController : Controller
    {
        private LTS db = new LTS();

        // GET: CaseManagers
        public ActionResult Index()
        {
            return View(db.CaseManagers.ToList());
        }

        // GET: CaseManagers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseManager caseManager = db.CaseManagers.Find(id);
            if (caseManager == null)
            {
                return HttpNotFound();
            }
            return View(caseManager);
        }

        // GET: CaseManagers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaseManagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FirstNameCM,LastNameCM")] CaseManager caseManager)
        {
            if (ModelState.IsValid)
            {
                db.CaseManagers.Add(caseManager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caseManager);
        }

        // GET: CaseManagers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseManager caseManager = db.CaseManagers.Find(id);
            if (caseManager == null)
            {
                return HttpNotFound();
            }
            return View(caseManager);
        }

        // POST: CaseManagers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FirstNameCM,LastNameCM")] CaseManager caseManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caseManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caseManager);
        }

        // GET: CaseManagers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseManager caseManager = db.CaseManagers.Find(id);
            if (caseManager == null)
            {
                return HttpNotFound();
            }
            return View(caseManager);
        }

        // POST: CaseManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CaseManager caseManager = db.CaseManagers.Find(id);
            db.CaseManagers.Remove(caseManager);
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
