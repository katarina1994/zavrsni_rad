using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web.DAL;
using web.Models;

namespace web.Controllers
{
    public class UrediRestoranController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: UrediRestoran
        public ActionResult Index()
        {
            return View(db.Restorani.ToList());
        }

        // GET: UrediRestoran/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restoran restoran = db.Restorani.Find(id);
            if (restoran == null)
            {
                return HttpNotFound();
            }
            return View(restoran);
        }

        // GET: UrediRestoran/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrediRestoran/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Naziv,Adresa,RadijusDostave,Location,Vrijeme_otvaranja,Vrijeme_zatvaranja")] Restoran restoran)
        {
            if (ModelState.IsValid)
            {
                db.Restorani.Add(restoran);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restoran);
        }

        // GET: UrediRestoran/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restoran restoran = db.Restorani.Find(id);
            if (restoran == null)
            {
                return HttpNotFound();
            }
            return View(restoran);
        }

        // POST: UrediRestoran/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naziv,Adresa,RadijusDostave,Location,Vrijeme_otvaranja,Vrijeme_zatvaranja")] Restoran restoran)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restoran).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restoran);
        }

        // GET: UrediRestoran/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restoran restoran = db.Restorani.Find(id);
            if (restoran == null)
            {
                return HttpNotFound();
            }
            return View(restoran);
        }

        // POST: UrediRestoran/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restoran restoran = db.Restorani.Find(id);
            db.Restorani.Remove(restoran);
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
