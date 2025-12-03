using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HR.Models;

namespace HR.Controllers
{
    public class EmployeeAttendancesController : Controller
    {
        private dberpEntities db = new dberpEntities();

        // GET: EmployeeAttendances
        public ActionResult Index()
        {
            return View(db.EmployeeAttendances.ToList());
        }

        // GET: EmployeeAttendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAttendance employeeAttendance = db.EmployeeAttendances.Find(id);
            if (employeeAttendance == null)
            {
                return HttpNotFound();
            }
            return View(employeeAttendance);
        }

        // GET: EmployeeAttendances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeAttendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttendanceID,EmployeeID,Date,Status")] EmployeeAttendance employeeAttendance)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeAttendances.Add(employeeAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeAttendance);
        }

        // GET: EmployeeAttendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAttendance employeeAttendance = db.EmployeeAttendances.Find(id);
            if (employeeAttendance == null)
            {
                return HttpNotFound();
            }
            return View(employeeAttendance);
        }

        // POST: EmployeeAttendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttendanceID,EmployeeID,Date,Status")] EmployeeAttendance employeeAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeAttendance);
        }

        // GET: EmployeeAttendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAttendance employeeAttendance = db.EmployeeAttendances.Find(id);
            if (employeeAttendance == null)
            {
                return HttpNotFound();
            }
            return View(employeeAttendance);
        }

        // POST: EmployeeAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeAttendance employeeAttendance = db.EmployeeAttendances.Find(id);
            db.EmployeeAttendances.Remove(employeeAttendance);
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
