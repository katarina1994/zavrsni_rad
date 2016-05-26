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
    public class OdabranoJeloController : Controller
    {


        private DatabaseContext db = new DatabaseContext();

       

        // GET: OdabranoJelo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

     
        public bool Create(int newID, int newKolicina, string newMail, string newAdresa, string newVrijeme, int newJeloID, int newRestoranID, int newUkupnaCijena)
        {


            var odab_jelo = new OdabranoJelo { ID = newID, Kolicina = newKolicina, Mail = newMail, Adresa = newAdresa, Vrijeme = newVrijeme, JeloID = newJeloID, RestoranID = newRestoranID, UkupnaCijena = newUkupnaCijena };
            if (!ModelState.IsValid)
            {
                return false;
            }

            db.OdabranaJela.Add(odab_jelo);
            db.SaveChanges();

            return true;
        }

        // GET: OdabranoJelo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OdabranoJelo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OdabranoJelo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OdabranoJelo/Delete/5
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
