using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp
{
    public class BooksDataModel
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(512)]
        public string Title { get; set; }

        [Required]
        public AuthorsDataModel Author { get; set; }

        public SeriesDataModel Series { get; set; }
    }
}