using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicLibrary
{
    interface ILibraryServices
    {
        bool AddBook(AcademicLibrary library, Book book);
        bool DeleteBook(AcademicLibrary library, string book_name);
        dynamic SearchBook(AcademicLibrary library, string book_name);
        bool DisplayRecentlyAddedBook(AcademicLibrary library);
    }
}
