using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zeus.OneSignalMVC.Models;

namespace Zeus.OneSignalMVC.Data.CoreModels
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(OneSignalDBContext context)
        : base(context)
        {
        }
    }
}