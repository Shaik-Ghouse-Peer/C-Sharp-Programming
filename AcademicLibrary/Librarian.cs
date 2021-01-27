using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AcademicLibrary
{
    class Librarian : ILibraryServices
    {
        public bool AddBook(AcademicLibrary library, Book book)
        {
            library.books_rake.Add(book);
            library.recently_added_book = book;

            return true;
        }
        public dynamic SearchBook(AcademicLibrary library, string book_name)
        {
            foreach (dynamic book in library.books_rake)
            {
                if (book.name == book_name)
                {
                    return book;
                }
            }
            return false;
        }
        public bool DeleteBook(AcademicLibrary library, string book_name)
        {
            var search_result_book = SearchBook(library, book_name);

            if (!(search_result_book is bool))
            {
                library.books_rake.Remove(search_result_book);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DisplayRecentlyAddedBook(AcademicLibrary library)
        {
            if (library.recently_added_book == null || IsBookDeleted(library, library.recently_added_book))
            {
                return false;
            }
            else
            {
                library.recently_added_book.DisplayDetails();
                return true;
            }
        }
        private bool IsBookDeleted(AcademicLibrary library, Book book)
        {
            dynamic search_result = SearchBook(library, book.name);

            if (search_result is bool)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
