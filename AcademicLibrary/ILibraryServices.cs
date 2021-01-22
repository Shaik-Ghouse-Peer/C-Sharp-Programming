using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicLibrary
{
    interface ILibraryServices
    {
        dynamic AddBook(dynamic library, dynamic book);
        dynamic DeleteBook(dynamic library, dynamic book);
        dynamic SearchBook(dynamic library, dynamic book);
        dynamic DisplayRecentlyAddedBook(dynamic library);
    }
}
