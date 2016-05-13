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

    [RoutePrefix("api/OdabranoJeloVoditelj")]
    public class OdabranoJeloVoditeljController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/OdabranoJeloVoditelj
        public IQueryable<OdabranoJelo> GetOdabranaJela()
        {
            return db.OdabranaJela;
        }

        // GET: api/OdabranoJeloVoditelj/5
        [ResponseType(typeof(OdabranoJelo))]
        public IHttpActionResult GetOdabranoJelo(int id)
        {
            OdabranoJelo odabranoJelo = db.OdabranaJela.Find(id);
            if (odabranoJelo == null)
            {
                return NotFound();
            }

            return Ok(odabranoJelo);
        }

        // PUT: api/OdabranoJeloVoditelj/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOdabranoJelo(int id, OdabranoJelo odabranoJelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != odabranoJelo.ID)
            {
                return BadRequest();
            }

            db.Entry(odabranoJelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OdabranoJeloExists(id))
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

        // POST: api/OdabranoJeloVoditelj
        [ResponseType(typeof(OdabranoJelo))]
        public IHttpActionResult PostOdabranoJelo(OdabranoJelo odabranoJelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OdabranaJela.Add(odabranoJelo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = odabranoJelo.ID }, odabranoJelo);
        }

        // DELETE: api/OdabranoJeloVoditelj/5
        [ResponseType(typeof(OdabranoJelo))]
        public IHttpActionResult DeleteOdabranoJelo(int id)
        {
            OdabranoJelo odabranoJelo = db.OdabranaJela.Find(id);
            if (odabranoJelo == null)
            {
                return NotFound();
            }

            db.OdabranaJela.Remove(odabranoJelo);
            db.SaveChanges();

            return Ok(odabranoJelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OdabranoJeloExists(int id)
        {
            return db.OdabranaJela.Count(e => e.ID == id) > 0;
        }
    }
}