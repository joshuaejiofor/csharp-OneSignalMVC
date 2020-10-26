using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Zeus.OneSignalMVC.Data;
using Zeus.OneSignalMVC.Models;
using Zeus.OneSignalMVC.Services;

namespace Zeus.OneSignalMVC.Controllers
{
    [Authorize]
    public class AppController : ControllerShared
    { 
        public AppController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, OneSignalDBContext context, IMapper mapper, IAppService appService)
            : base(userManager, signInManager, context, mapper, appService) 
        {
        }

        public async Task<ActionResult> Index()
        {
            IEnumerable<AppViewModel> apps = await AppService.GetAllApps();

            if(!apps.Any())
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
           
            ViewBag.IsAdmin = IsAdminUser();
            return View(apps);
        }

        public async Task<ActionResult> Details(string Id)
        {
            AppViewModel app = await AppService.GetApp(Id);

            if(app == null)
            {
                app = new AppViewModel();

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            ViewBag.IsAdmin = IsAdminUser();
            return View(app);
        }

        public async Task<ActionResult> Edit(string Id)
        {
            if (!IsAdminUser())
            {
                ModelState.AddModelError(string.Empty, "Unauthorized Access.");
                return RedirectToAction("Index");
            }

            AppViewModel app = await AppService.GetApp(Id);

            if (app == null)
            {
                app = new AppViewModel();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            var appUpdateModel = Mapper.Map<AppUpdateModel>(app);
            appUpdateModel.Id = Id;

            ViewBag.IsAdmin = IsAdminUser();
            return View(appUpdateModel);
        }


        [HttpPost]
        public async Task<ActionResult> Edit(AppUpdateModel appUpdateModel)
        {
            if (ModelState.IsValid)
            {
                var appCreateModel = Mapper.Map<AppCreateModel>(appUpdateModel);
                var isUpdated = await AppService.UpdateApp(appUpdateModel.Id, appCreateModel);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Request.");
            }

            ViewBag.IsAdmin = IsAdminUser();
            return View(appUpdateModel);
        }

        public ActionResult Create()
        {
            if (!IsAdminUser())
            {
                ModelState.AddModelError(string.Empty, "Unauthorized Access.");
                return RedirectToAction("Index");
            }

            ViewBag.IsAdmin = IsAdminUser();
            return View(new AppCreateModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(AppCreateModel appCreateModel)
        {
            if (ModelState.IsValid)
            {
                var isCreated = await AppService.CreateApp(appCreateModel);
                if (isCreated)
                {
                    return RedirectToAction("Index");
                }
                
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");                    
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Request.");                
            }

            ViewBag.IsAdmin = IsAdminUser();
            return View(appCreateModel);
        }


    }
}