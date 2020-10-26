using AutoMapper;
using System.Web.Mvc;
using Zeus.OneSignalMVC.Data;
using Zeus.OneSignalMVC.Services;

namespace Zeus.OneSignalMVC.Controllers
{
    public class HomeController : ControllerShared
    {
        public HomeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, OneSignalDBContext context, IMapper mapper, IAppService appService)
            : base(userManager, signInManager, context, mapper, appService)
        {
        }

        public ActionResult Index()
        {
            ViewBag.IsAdmin = IsAdminUser();
            return View();
        }
    }
}