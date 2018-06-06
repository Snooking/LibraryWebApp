using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp
{
    public class SeriesDataModel
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(512)]
        public string Name { get; set; }

        [Required]
        public AuthorsDataModel Author { get; set; }

        public List<BooksDataModel> Books { get; set; }
    }
}