using web.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace web.DAL
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DatabaseContext() : base("DatabaseContext", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Ovlast> Ovlasti { get; set; }
        public DbSet<Restoran> Restorani { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }
    }
}