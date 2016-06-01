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
    public class KorisnikController : Controller
    {

        private DatabaseContext db = new DatabaseContext();
        // GET: Korisnik
        public ActionResult Index()
        {
            return View();
        }

        // GET: Korisnik/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: Korisnik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Korisnik/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public bool Edit(string id, string username, string ime, string prez, string majl, int oid, int rid)
        {
            Korisnik korisnik = new Korisnik{ Id = id, UserName = username, Ime = ime, Prezime = prez, Mail = majl, OvlastID = oid, RestID = rid };

            if (ModelState.IsValid)
            {
                db.Entry(korisnik).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        // POST: Korisnik/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
