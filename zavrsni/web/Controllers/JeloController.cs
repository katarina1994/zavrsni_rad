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
    [RoutePrefix("api/Jela")]
    public class JeloController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Jelo
        public IQueryable<Jelo> GetJela()
        {
            return db.Jela;
        }


        [AcceptVerbs("GET")]
        [Route("GetJelaByID/{id:int}")]
        public IQueryable<Jelo> GetJelaByID(int id)
        {
            return db.Jela.Where(s => s.RestoranID == id);
        }


        [AcceptVerbs("GET")]
        [Route("getJelaTheirID/{id:int}")]
        public IQueryable<Jelo> getJelaTheirID(int id)
        {
            return db.Jela.Where(s => s.ID == id);
        }

        // GET: api/Jelo/5
        [ResponseType(typeof(Jelo))]
        public IHttpActionResult GetJelo(int id)
        {
            Jelo jelo = db.Jela.Find(id);
            if (jelo == null)
            {
                return NotFound();
            }

            return Ok(jelo);
        }

        // PUT: api/Jelo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJelo(int id, Jelo jelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jelo.ID)
            {
                return BadRequest();
            }

            db.Entry(jelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JeloExists(id))
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

       

        // DELETE: api/Jelo/5
        [AcceptVerbs("GET")]
        [Route("DeleteJelo/{id:int}")]
        public IHttpActionResult DeleteJelo(int id)
        {
            Jelo jelo = db.Jela.Find(id);
            if (jelo == null)
            {
                return NotFound();
            }

            db.Jela.Remove(jelo);
            db.SaveChanges();

            return Ok(jelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JeloExists(int id)
        {
            return db.Jela.Count(e => e.ID == id) > 0;
        }
    }
}