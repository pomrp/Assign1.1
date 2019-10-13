﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assign1._1.Models;

namespace Assign1._1.Controllers
{
    public class FeedBacksController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: FeedBacks
        public ActionResult Index()
        {
            var feedBacks = db.FeedBacks.Include(f => f.Booking);
            return View(feedBacks.ToList());
        }

        // GET: FeedBacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = db.FeedBacks.Find(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            return View(feedBack);
        }

        // GET: FeedBacks/Create
        public ActionResult Create()
        {
            ViewBag.BookingId = new SelectList(db.Bookings, "Id", "UserID");
            return View();
        }

        // POST: FeedBacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,Date,Rate,BookingId")] FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                db.FeedBacks.Add(feedBack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookingId = new SelectList(db.Bookings, "Id", "UserID", feedBack.BookingId);
            return View(feedBack);
        }

        // GET: FeedBacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = db.FeedBacks.Find(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingId = new SelectList(db.Bookings, "Id", "UserID", feedBack.BookingId);
            return View(feedBack);
        }

        // POST: FeedBacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,Date,Rate,BookingId")] FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedBack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingId = new SelectList(db.Bookings, "Id", "UserID", feedBack.BookingId);
            return View(feedBack);
        }

        // GET: FeedBacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = db.FeedBacks.Find(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            return View(feedBack);
        }

        // POST: FeedBacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeedBack feedBack = db.FeedBacks.Find(id);
            db.FeedBacks.Remove(feedBack);
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
