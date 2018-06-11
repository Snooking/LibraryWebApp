using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp
{
    public class AuthorsDataModel
    {
        [Key]
        public int Id { get; set; }

        [Required ,MaxLength(256)]
        public string Name { get; set; }

        [Required, MaxLength(256)]
        public string Surname { get; set; }

        public List<BooksDataModel> Books { get; set; }

        public List<SeriesDataModel> Series { get; set; }
    }
}