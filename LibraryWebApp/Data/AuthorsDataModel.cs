using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp
{
    public class AuthorsDataModel
    {
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Surname { get; set; }

        public List<BooksDataModel> Books { get; set; }

        public List<SeriesDataModel> Series { get; set; }
    }
}