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
    public class CasesController : Controller
    {
        private LTS db = new LTS();

        // GET: Cases
        public ActionResult Index()
        {
            var cases = db.Cases.Include(a => a.CaseManager).Include(b => b.Student).Include(c => c.TeachingAssistant).Include(d => d.Unit);
            return View(cases.ToList());
        }

        // GET: Cases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // GET: Cases/Create
        public ActionResult Create()
        {
            List<string>[] names = getThatList();

            ViewBag.CaseManager_id = new SelectList(names[0]);
            ViewBag.TeachingAssistant_id = new SelectList(names[1]);
            ViewBag.Student_id = new SelectList(names[2]);
            ViewBag.Unit_id = new SelectList(db.Units, "id", "UnitCode");
            return View();
        }


        public List<string>[] getThatList()
        {
            List<CaseManager> CMs = db.CaseManagers.ToList();
            List<string> CMNames = new List<string>();

            foreach (CaseManager i in CMs)
            {
                CMNames.Add(i.FullNameCM);
            }


            List<TeachingAssistant> TAs = db.TeachingAssistants.ToList();
            List<string> TANames = new List<string>();

            foreach (TeachingAssistant i in TAs)
            {
                TANames.Add(i.FullNameTA);
            }

            List<Student> Stus = db.Students.ToList();
            List<string> StuNames = new List<string>();

            foreach (Student i in Stus)
            {
                StuNames.Add(i.Alias);
            }

            List<string>[] s1 = { CMNames, TANames, StuNames };

            return s1;
        }
        // POST: Cases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,CaseId,CaseManager_id,Student_id,TeachingAssistant_id,Unit_id")] Case @case)
        {


            if (ModelState.IsValid)
            {
                db.Cases.Add(@case);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<string>[] names = getThatList();

            ViewBag.CaseManager_id = new SelectList(names[0]);
            ViewBag.TeachingAssistant_id = new SelectList(names[1]);
            ViewBag.Student_id = new SelectList(names[2]);
            ViewBag.Unit_id = new SelectList(db.Units, "id", "UnitCode");



            //ViewBag.CaseManager_id = new SelectList(db.CaseManagers, "id", "FirstNameCM", @case.CaseManager.FirstNameCM);
            //ViewBag.Student_id = new SelectList(db.Students, "id", "Alias", @case.Student.Alias);
            //ViewBag.TeachingAssistant_id = new SelectList(db.TeachingAssistants, "id", "FirstNameTA", @case.TeachingAssistant.FirstNameTA);
            //ViewBag.Unit_id = new SelectList(db.Units, "id", "UnitCode", @case.Unit.UnitCode);
            return View(@case);
        }

        // GET: Cases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            ViewBag.CaseManager_id = new SelectList(db.CaseManagers, "id", "FullNameCM", @case.CaseManager.FullNameCM);
            ViewBag.Student_id = new SelectList(db.Students, "id", "Alias", @case.Student.Alias);
            ViewBag.TeachingAssistant_id = new SelectList(db.TeachingAssistants, "id", "FullNameTA", @case.TeachingAssistant.FullNameTA);
            ViewBag.Unit_id = new SelectList(db.Units, "id", "UnitCode", @case.Unit.UnitCode);
            return View(@case);
        }

        // POST: Cases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CaseId,CaseManager_id,Student_id,TeachingAssistant_id,Unit_id")] Case @case)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@case).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CaseManager_id = new SelectList(db.CaseManagers, "id", "FullNameCM", @case.CaseManager.FullNameCM);
            ViewBag.Student_id = new SelectList(db.Students, "id", "Alias", @case.Student.Alias);
            ViewBag.TeachingAssistant_id = new SelectList(db.TeachingAssistants, "id", "FullNameTA", @case.TeachingAssistant.FullNameTA);
            ViewBag.Unit_id = new SelectList(db.Units, "id", "UnitCode", @case.Unit.UnitCode);
            return View(@case);
        }

        // GET: Cases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Case @case = db.Cases.Find(id);
            db.Cases.Remove(@case);
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
