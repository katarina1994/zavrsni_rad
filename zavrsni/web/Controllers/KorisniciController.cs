using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using web.DAL;
using web.Infrastructure;
using web.Models;

namespace web.Controllers
{
    public class KorisniciController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Korisnici
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Password,ConfirmPassword,Ime,Prezime,Mail,OvlastID,RestID")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(korisnik);
        }

        // GET: Korisnici/Delete/5
        public async Task<HttpResponseMessage> Delete(string id)
        {
            
            if (id != null)
            {
                try
                {
                    using (DatabaseContext dbcontext = new DatabaseContext())
                    {
                        

                        dbcontext.Users.Remove(dbcontext.Users.Where(usr => usr.Id == id).Single());

                        dbcontext.SaveChanges();
                    }
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Error occurred while deleting user: {0}", ex.ToString());
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        // POST: Korisnici/Delete/5


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
