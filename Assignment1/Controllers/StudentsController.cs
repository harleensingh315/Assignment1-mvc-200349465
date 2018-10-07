using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class StudentsController : Controller
    {
        private students_dbEntities db = new students_dbEntities();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Tbl_Students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Students tbl_Students = db.Tbl_Students.Find(id);
            if (tbl_Students == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Students);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Mobile,Address,CourseId")] Tbl_Students tbl_Students)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Students.Add(tbl_Students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Students);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Students tbl_Students = db.Tbl_Students.Find(id);
            if (tbl_Students == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Mobile,Address,CourseId")] Tbl_Students tbl_Students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Students);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Students tbl_Students = db.Tbl_Students.Find(id);
            if (tbl_Students == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Students tbl_Students = db.Tbl_Students.Find(id);
            db.Tbl_Students.Remove(tbl_Students);
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
