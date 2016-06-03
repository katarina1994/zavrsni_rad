using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using web.Models;
using System.Data.Entity;
using web.Repositories;
using web.DAL;
using web.Infrastructure;
using System.Linq;
using System.Collections.Generic;

namespace web.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;

        public AccountController()
        {
            _repo = new AuthRepository();
        }

        [AllowAnonymous]
        [Route("GetUsers")]
        public async Task<List<Korisnik>> GetUsersAsync()
        {
            using (var context = new DatabaseContext())
            {
                return await context.IdentityUsers.ToListAsync();
            }
        }


        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(Korisnik userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            userModel.OvlastID = 2;

            IdentityResult result = await _repo.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            switch (userModel.OvlastID)
            {
                case 1:
                    return Ok("admin");
                case 2:
                    return Ok("profile");
                case 3:
                    return Ok("voditelj");

                default:
                    return Ok("");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}