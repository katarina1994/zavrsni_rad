﻿using System;
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
    public class SaveJeloController : Controller
    {

        private DatabaseContext db = new DatabaseContext();

        // GET: SaveJelo
        public ActionResult Index()
        {
            return View();
        }

        // GET: SaveJelo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    

        public bool Create(string newNaziv_jelo, int newCijena, string newKratki_opis, int newTipJelaID, int newRestoranID)
        {


            var jelo = new Jelo {Naziv_jelo = newNaziv_jelo, Cijena = newCijena, Kratki_opis = newKratki_opis, TipJelaID = newTipJelaID, RestoranID = newRestoranID };

            foreach (Jelo e in db.Jela)
            {
                if (String.Equals(e.Naziv_jelo, jelo.Naziv_jelo, StringComparison.CurrentCultureIgnoreCase)
                    && (e.Cijena == jelo.Cijena)
                    && String.Equals(e.Kratki_opis, jelo.Kratki_opis, StringComparison.CurrentCultureIgnoreCase)
                    && (e.TipJelaID == jelo.TipJelaID) && (e.RestoranID == jelo.RestoranID))
                    return true;
            }

            if (!ModelState.IsValid)
            {
                return false;
            }

            db.Jela.Add(jelo);
            db.SaveChanges();

            return true;
        }

        // GET: SaveJelo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaveJelo/Edit/5
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

     
    }
}
