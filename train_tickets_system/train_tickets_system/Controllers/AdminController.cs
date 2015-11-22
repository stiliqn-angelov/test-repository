﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using train_tickets_system.Models;

namespace train_tickets_system.Controllers
{
    public class AdminController : Controller
    {
        private ProjectDBContext db = new ProjectDBContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Trips.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip Trips = db.Trips.Find(id);
            if (Trips == null)
            {
                return HttpNotFound();
            }
            return View(Trips);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DepartureTime,ArrivalTime")] Trip Trips)
        {
            if (ModelState.IsValid)
            {
                db.Trips.Add(Trips);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Trips);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip Trips = db.Trips.Find(id);
            if (Trips == null)
            {
                return HttpNotFound();
            }
            return View(Trips);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DepartureTime,ArrivalTime")] Trip Trips)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Trips).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Trips);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip Trips = db.Trips.Find(id);
            if (Trips == null)
            {
                return HttpNotFound();
            }
            return View(Trips);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trip Trips = db.Trips.Find(id);
            db.Trips.Remove(Trips);
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
