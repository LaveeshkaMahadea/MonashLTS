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
    public class CommentsController : Controller
    {
        private LTS db = new LTS();

        // GET: Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Case).Include(c => c.CaseManager);
            return View(comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.CurrentCase_id = new SelectList(db.Cases, "id", "CaseId");
            ViewBag.AssignedCM_id = new SelectList(db.CaseManagers, "id", "FullNameCM");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,CreatedDate,CommentText,Action,ClosedDate,AssignedCM_id,CurrentCase_id")] Comment comment)
        {
            comment.CaseManager = db.CaseManagers.Find(comment.AssignedCM_id);
            comment.Case = db.Cases.Find(comment.CurrentCase_id);

            comment.CreatedDate = DateTime.UtcNow;

            if (comment.Action == "Closed")
            {
                comment.ClosedDate = DateTime.UtcNow;
            }

            ModelState.Clear();
            TryValidateModel(comment);

            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrentCase_id = new SelectList(db.Cases, "id", "CaseId", comment.CurrentCase_id);
            ViewBag.AssignedCM_id = new SelectList(db.CaseManagers, "id", "FullNameCM", comment.AssignedCM_id);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrentCase_id = new SelectList(db.Cases, "id", "CaseId", comment.CurrentCase_id);
            ViewBag.AssignedCM_id = new SelectList(db.CaseManagers, "id", "FirstNameCM", comment.AssignedCM_id);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CreatedDate,CommentText,Action,ClosedDate,AssignedCM_id,CurrentCase_id")] Comment comment)
        {
            if (comment.Action == "Closed")
            {
                comment.ClosedDate = DateTime.Now;
            }

            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurrentCase_id = new SelectList(db.Cases, "id", "CaseId", comment.CurrentCase_id);
            ViewBag.AssignedCM_id = new SelectList(db.CaseManagers, "id", "FirstNameCM", comment.AssignedCM_id);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
