using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace LibraryWebApp.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext Db = new ApplicationDbContext();

        private async Task<BooksDataModel> FindBookViaId(int? id)
        {
            if (id == null) return Db.Books.First();

            var book = await Db.Books
                    .Include(b => b.Author)
                    .Include(b => b.Series)
                    .SingleOrDefaultAsync(b => b.Id == id);

            return book;
        }

        public ActionResult Index()
        {
            return View(Db.Books.Include(a => a.Author).Include(a => a.Series).ToList());
        }

        public async Task<ActionResult> Edit(int? id)
        {
            return View(await FindBookViaId(id));
        }

        public async Task<ActionResult> Details(int? id)
        {
            return View(await FindBookViaId(id));
        }

        public async Task<ActionResult> Delete(int? id)
        {
            return View(await FindBookViaId(id));
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}