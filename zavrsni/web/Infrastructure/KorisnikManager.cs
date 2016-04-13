using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.DAL;
using web.Models;

namespace web.Infrastructure
{
    public class KorisnikManager : UserManager<Korisnik>
    {
        public KorisnikManager(IUserStore<Korisnik> store) : base(store)
        {
        }

        public static KorisnikManager Create(IdentityFactoryOptions<KorisnikManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<DatabaseContext>();
            var appUserManager = new KorisnikManager(new UserStore<Korisnik>(appDbContext));

            return appUserManager;
        }
    }
}