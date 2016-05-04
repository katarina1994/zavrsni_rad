using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using web.DAL;
using web.Models;

namespace web.Controllers
{

    [RoutePrefix("api/TipJela")]
    public class TipJelaController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/TipJela
        public IQueryable<TipJela> GetTipovi()
        {
            return db.Tipovi;
        }


        [AcceptVerbs("GET")]
        [Route("GetTipJelaByID/{id:int}")]
        public IQueryable<TipJela> GetTipJelaByID(int id)
        {
            return db.Tipovi.Where(s => s.ID == id);
        }

        // GET: api/TipJela/5
        [ResponseType(typeof(TipJela))]
        public IHttpActionResult GetTipJela(int id)
        {
            TipJela tipJela = db.Tipovi.Find(id);
            if (tipJela == null)
            {
                return NotFound();
            }

            return Ok(tipJela);
        }

        // PUT: api/TipJela/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipJela(int id, TipJela tipJela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipJela.ID)
            {
                return BadRequest();
            }

            db.Entry(tipJela).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipJelaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TipJela
        [ResponseType(typeof(TipJela))]
        public IHttpActionResult PostTipJela(TipJela tipJela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tipovi.Add(tipJela);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipJela.ID }, tipJela);
        }

        // DELETE: api/TipJela/5
        [ResponseType(typeof(TipJela))]
        public IHttpActionResult DeleteTipJela(int id)
        {
            TipJela tipJela = db.Tipovi.Find(id);
            if (tipJela == null)
            {
                return NotFound();
            }

            db.Tipovi.Remove(tipJela);
            db.SaveChanges();

            return Ok(tipJela);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipJelaExists(int id)
        {
            return db.Tipovi.Count(e => e.ID == id) > 0;
        }
    }
}