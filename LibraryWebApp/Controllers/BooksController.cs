using System.Linq;
using System.Web.Mvc;

namespace LibraryWebApp.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext Db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(Db.Books.ToList());
        }
    }
}