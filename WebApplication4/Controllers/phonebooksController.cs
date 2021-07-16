using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class phonebooksController : Controller
    {
        private PhonebookDB db = new PhonebookDB();

        // GET: phonebooks
        public ActionResult Index()
        {
            return View(db.Phonebooks.ToList());
        }

        // GET: phonebooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phonebook phonebook = db.Phonebooks.Find(id);
            if (phonebook == null)
            {
                return HttpNotFound();
            }
            return View(phonebook);
        }

        // GET: phonebooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: phonebooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,number")] phonebook phonebook)
        {
            if (ModelState.IsValid)
            {
                db.Phonebooks.Add(phonebook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phonebook);
        }

        // GET: phonebooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phonebook phonebook = db.Phonebooks.Find(id);
            if (phonebook == null)
            {
                return HttpNotFound();
            }
            return View(phonebook);
        }

        // POST: phonebooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,number")] phonebook phonebook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phonebook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phonebook);
        }

        // GET: phonebooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phonebook phonebook = db.Phonebooks.Find(id);
            if (phonebook == null)
            {
                return HttpNotFound();
            }
            return View(phonebook);
        }

        // POST: phonebooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            phonebook phonebook = db.Phonebooks.Find(id);
            db.Phonebooks.Remove(phonebook);
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
