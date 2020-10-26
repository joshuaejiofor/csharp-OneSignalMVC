using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Web;
using System.Web.Mvc;
using Zeus.OneSignalMVC.Data;
using Zeus.OneSignalMVC.Mappers;
using Zeus.OneSignalMVC.Services;

namespace Zeus.OneSignalMVC.Controllers
{
    public class ControllerShared : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private OneSignalDBContext _context;
        private AppService _appService;
        protected IMapper _mapper = AppMap.AppMapConfig();

        public ControllerShared()
        {            
        }

        public ControllerShared(ApplicationUserManager userManager, ApplicationSignInManager signInManager, OneSignalDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public OneSignalDBContext Context
        {
            get
            {
                return _context ?? HttpContext.GetOwinContext().Get<OneSignalDBContext>();
            }
            private set
            {
                _context = value;
            }
        }

        public AppService AppService
        {
            get
            {
                return _appService ?? HttpContext.GetOwinContext().Get<AppService>();
            }
            private set
            {
                _appService = value;
            }
        }

        public Boolean IsAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                var s = UserManager.GetRoles(user.GetUserId());
                if (s.Count > 0 && s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }

                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}