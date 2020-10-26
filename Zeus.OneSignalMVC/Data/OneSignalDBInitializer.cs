using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Configuration;
using Zeus.OneSignalMVC.Models;

namespace Zeus.OneSignalMVC.Data
{
    public class OneSignalDBInitializer : DropCreateDatabaseIfModelChanges<OneSignalDBContext>
    {
        protected override void Seed(OneSignalDBContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            IList<string> roles = new List<string> { "Admin", "Operator" };

            roles.ForEach(item =>
            {
                if (!roleManager.RoleExists(item))
                {

                    // first we create role
                    var role = new IdentityRole() { Name = item };
                    roleManager.Create(role);

                    //Here we create a user for each role  
                    var email = $"{item.ToLower()}@gmail.com";
                    var user = new ApplicationUser()
                    {
                        UserName = email,
                        Email = email,
                        LockoutEnabled = true
                    };

                    string userPWD = WebConfigurationManager.AppSettings["DefaultAccountPassword"];

                    var chkUser = UserManager.Create(user, userPWD);

                    //Add User to Role  
                    if (chkUser.Succeeded)
                    {
                        UserManager.AddToRole(user.Id, item);
                    }
                }
            });

            base.Seed(context);
        }
    }
}