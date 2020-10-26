using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zeus.OneSignalMVC.Controllers
{
    public class HomeController : ControllerShared
    {
        public ActionResult Index()
        {
            ViewBag.IsAdmin = IsAdminUser();
            return View();
        }
    }
}