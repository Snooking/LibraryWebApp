using System.Web.Mvc;

namespace LibraryWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Library web app.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}