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
        private readonly ApplicationSignInManager _signInManager;
        private readonly ApplicationUserManager _userManager;
        private readonly OneSignalDBContext _context;
        private readonly IAppService _appService;
        private readonly IMapper _mapper;

        public ControllerShared(ApplicationUserManager userManager, 
                                ApplicationSignInManager signInManager, 
                                OneSignalDBContext context, 
                                IMapper mapper, 
                                IAppService appService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _mapper = mapper;
            _appService = appService;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager;
            }
        }

        public OneSignalDBContext Context
        {
            get
            {
                return _context;
            }
        }

        public IAppService AppService
        {
            get
            {
                return _appService;
            }
        }

        public IMapper Mapper
        {
            get
            {
                return _mapper;
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
        
    }
}