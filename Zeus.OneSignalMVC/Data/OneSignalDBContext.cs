using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Zeus.OneSignalMVC.Models;

namespace Zeus.OneSignalMVC.Data
{
    public class OneSignalDBContext : IdentityDbContext<ApplicationUser>
    {
        public OneSignalDBContext() : base("OneSignalConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new OneSignalDBInitializer());
        }
        public static OneSignalDBContext Create()
        {
            return new OneSignalDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }    
}