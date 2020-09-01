using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProfileViewer.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["token"] = null;
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult SetToken(string token)
        {
            Session["token"] = "Bearer " + token;
            return Json("Done", JsonRequestBehavior.AllowGet);
        }
    }
}