using System.Web.Mvc;

namespace ProfileViewer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["token"] == null)
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            if (Session["token"] == null)
                return RedirectToAction("Login", "Account");

            return PartialView("_dashboard");
        }

        [HttpGet]
        public ActionResult UserProfile()
        {
            if (Session["token"] == null)
                return RedirectToAction("Login", "Account");

            return PartialView("_profile");
        }

        [HttpPost]
        public ActionResult UpdateProfile()
        {
            if (Session["token"] == null)
                return RedirectToAction("Login", "Account");

            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Works()
        {
            if (Session["token"] == null)
                return RedirectToAction("Login", "Account");

            return PartialView("_works");
        }
    }
}