using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LibraryWebApp.Controllers
{
    public class AuthorsController : Controller
    {
        private ApplicationDbContext Db = new ApplicationDbContext();

        private async Task<AuthorsDataModel> FindAuthor(string name, string surname)
        {
            if (name.Length <= 1 || surname.Length <= 1) return Db.Authors.First();

            var author = await Db.Authors
                    .Include(a => a.Books)
                    .Include(a => a.Series)
                    .SingleOrDefaultAsync(a => a.Name == name && a.Surname == surname);

            return author;
        }

        public ActionResult Index()
        {
            return View(Db.Authors.ToList());
        }

        public async Task<ActionResult> Edit(string name, string surname)
        {
            return View(await FindAuthor(name, surname));
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAuthor(int? id, string oldName)
        {
            var author = Db.Authors.Find(id);
            TryUpdateModel(author, "", new string[] { "Name", "Surname" });
            await Db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(string name, string surname)
        {
            return View(await FindAuthor(name, surname));
        }

        public async Task<ActionResult> Delete(string name, string surname)
        {
            return View(await FindAuthor(name, surname));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(AuthorsDataModel author)
        {
            try
            {
                Db.Authors.Attach(author);
                Db.Authors.Remove(author);
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AuthorsDataModel author)
        {
            if (ModelState.IsValid)
            {
                Db.Authors.Add(author);
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}