using Core.Service;
using Core.ViewModel;
using Microsoft.AspNet.Identity;
using ProfileViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProfileViewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService userService;
        private readonly WorksService worksService;
        public HomeController()
        {
            userService = new UserService();
            worksService = new WorksService();
        }

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            return PartialView("_dashboard");
        }

        [HttpGet]
        public ActionResult UserProfile()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            return PartialView("_profile", userService.GetUserProfileByEmail(User.Identity.GetUserName()));
        }

        [HttpPost]
        public ActionResult UpdateProfile(ProfileViewModel model)
        {
            return Json(userService.UpdateProfile(model), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Works()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            return PartialView("_works");
        }

        [HttpPost]
        public ActionResult GetWorksOfLoggedUser()
        {
            if(!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            return Json(worksService.GetTaskForUser(User.Identity.GetUserName()), JsonRequestBehavior.AllowGet);
        }
    }
}