using System.Data.Entity;

namespace LibraryWebApp
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BooksDataModel> Books { get; set; }
        public DbSet<AuthorsDataModel> Authors { get; set; }
        public DbSet<SeriesDataModel> Series { get; set; }

        public ApplicationDbContext() : base("Library")
        {

        }
    }
}