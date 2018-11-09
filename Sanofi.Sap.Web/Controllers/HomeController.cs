using System.Web.Mvc;

namespace Sanofi.Sap.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Create Request";

            return View();
        }

        public ActionResult Review()
        {
            ViewBag.Title = "Create Request";

            return View();
        }
    }
}
