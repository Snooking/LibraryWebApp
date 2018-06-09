using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;

namespace LibraryWebApp.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext Db = new ApplicationDbContext();

        private BooksDataModel FindBookViaId(int? id)
        {
            if (id == null) return Db.Books.First();
            var book = (from b in Db.Books
                        where b.Id == id
                        select b)
                       .First();
                       
            return book;
        }

        public ActionResult Index()
        {
            return View(Db.Books.Include(a=>a.Author).Include(a=>a.Series).ToList());
        }

        public ActionResult Edit(int? id)
        {
            return View(FindBookViaId(id));
        }

        public ActionResult Details(int? id)
        {
            return View(FindBookViaId(id));
        }

        public ActionResult Delete(int? id)
        {
            return View(FindBookViaId(id));
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}