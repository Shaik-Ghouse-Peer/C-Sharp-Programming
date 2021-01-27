using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicLibrary
{
    abstract class LibraryDatabase   
    {
        public List<Book> books_rake;
        public dynamic recently_added_book;
        public int total_books_available;
 
        public LibraryDatabase()
        {
            this.books_rake = new List<Book>();
            this.total_books_available = 0;
        }

        abstract public bool DisplayBooksInLibrary();
    }
}
