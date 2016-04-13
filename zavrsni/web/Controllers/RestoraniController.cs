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
    [RoutePrefix("api/Restorani")]
    public class RestoraniController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Restorani
        public IQueryable<Restoran> GetRestorani()
        {
            return db.Restorani;
        }


        [AcceptVerbs("GET")]
        [Route("GetRestoraniByDistance/{id:int}")]
        public IQueryable<Restoran> GetRestoraniByDistance(int id)
        {
            return db.Restorani.Where(s => s.ID == id);
        }



        // GET: api/Restorani/5
        [ResponseType(typeof(Restoran))]
        public IHttpActionResult GetRestoran(int id)
        {
            Restoran restoran = db.Restorani.Find(id);
            if (restoran == null)
            {
                return NotFound();
            }

            return Ok(restoran);
        }

        // PUT: api/Restorani/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestoran(int id, Restoran restoran)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restoran.ID)
            {
                return BadRequest();
            }

            db.Entry(restoran).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestoranExists(id))
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

        // POST: api/Restorani
        [ResponseType(typeof(Restoran))]
        public IHttpActionResult PostRestoran(Restoran restoran)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Restorani.Add(restoran);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = restoran.ID }, restoran);
        }

        // DELETE: api/Restorani/5
        [ResponseType(typeof(Restoran))]
        public IHttpActionResult DeleteRestoran(int id)
        {
            Restoran restoran = db.Restorani.Find(id);
            if (restoran == null)
            {
                return NotFound();
            }

            db.Restorani.Remove(restoran);
            db.SaveChanges();

            return Ok(restoran);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestoranExists(int id)
        {
            return db.Restorani.Count(e => e.ID == id) > 0;
        }
    }
}