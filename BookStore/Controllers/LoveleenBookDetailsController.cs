using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoveleenEf_project1.Models;

namespace LoveleenEf_project1.Controllers
{
    public class LoveleenBookDetailsController : Controller
    {
        private LoveleenLibraryDB34Entities1 db = new LoveleenLibraryDB34Entities1();

        // GET: LoveleenBookDetails
        public ActionResult Index()
        {
            return View(db.LoveleenBookDetails.ToList());
        }

        // GET: LoveleenBookDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoveleenBookDetail loveleenBookDetail = db.LoveleenBookDetails.Find(id);
            if (loveleenBookDetail == null)
            {
                return HttpNotFound();
            }
            return View(loveleenBookDetail);
        }

        // GET: LoveleenBookDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoveleenBookDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,BookName,Price,Category,AuthorName,Edition,BookCondition,Available")] LoveleenBookDetail loveleenBookDetail)
        {
            if (ModelState.IsValid)
            {
                db.LoveleenBookDetails.Add(loveleenBookDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loveleenBookDetail);
        }

        // GET: LoveleenBookDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoveleenBookDetail loveleenBookDetail = db.LoveleenBookDetails.Find(id);
            if (loveleenBookDetail == null)
            {
                return HttpNotFound();
            }
            return View(loveleenBookDetail);
        }

        // POST: LoveleenBookDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,BookName,Price,Category,AuthorName,Edition,BookCondition,Available")] LoveleenBookDetail loveleenBookDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loveleenBookDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loveleenBookDetail);
        }

        // GET: LoveleenBookDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoveleenBookDetail loveleenBookDetail = db.LoveleenBookDetails.Find(id);
            if (loveleenBookDetail == null)
            {
                return HttpNotFound();
            }
            return View(loveleenBookDetail);
        }

        // POST: LoveleenBookDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoveleenBookDetail loveleenBookDetail = db.LoveleenBookDetails.Find(id);
            db.LoveleenBookDetails.Remove(loveleenBookDetail);
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
