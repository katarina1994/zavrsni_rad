using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Threading.Tasks;
using web.DAL;
using web.Models;

namespace web.Repositories
{
    public class AuthRepository : IDisposable
    {
        private DatabaseContext _ctx;

        private UserManager<Korisnik> _userManager;

        public AuthRepository()
        {
            _ctx = new DatabaseContext();
            _userManager = new UserManager<Korisnik>(new UserStore<Korisnik>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(Korisnik userModel)
        {
            try
            {
                var result = await _userManager.CreateAsync(userModel, userModel.Password);
                return result;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                return null;
            }
        }

        public async Task<Korisnik> FindUser(string userName, string password)
        {
            Korisnik user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}