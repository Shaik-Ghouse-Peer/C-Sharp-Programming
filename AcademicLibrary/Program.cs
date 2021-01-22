using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicLibrary
{
    class Program : LibraryDatabase
    {
        public override bool DisplayBooksInLibrary()
        {
            if (this.books_rake.Count <= 0)
            {
                return false;
            }
            else
            {
                Console.WriteLine("------------Books Available------------");
                foreach (dynamic book in this.books_rake)
                {
                    int book_index = 1;
                    Console.WriteLine("{0}-{1}", book_index, book.name);
                }
                Console.WriteLine("---------------------------------------");
                return true;
            }          
        }
        public dynamic CreateNewBook()
        {
            string book_name, author_name, category;
            int price;

            Console.WriteLine("Enter Book Name : ");
            book_name = Console.ReadLine();

            Console.WriteLine("EnterAuthor Name : ");
            author_name = Console.ReadLine();

            Console.WriteLine("Enter Book Category : ");
            category = Console.ReadLine();

            Console.WriteLine("Enter Book Price : ");
            price = Convert.ToInt32(Console.ReadLine());

            var new_book = new Book(book_name, author_name, category, price);

            return new_book;
        }
        static void Main()
        {
            dynamic academic_library = new Program();
            dynamic librarian_shaik = new Librarian();

            string menu_option;
            while (true)
            {
                Console.WriteLine("1.Display Books Avaialablle In Library\n2.Add Book\n3.Delete Book");
                Console.WriteLine("4.Search Book\n5.Display Recently Added Book\nPress Any Other Key To Exit : ");

                menu_option = Console.ReadLine();

                switch (menu_option)
                {
                    case "1":
                        if (academic_library.DisplayBooksInLibrary() == false)
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Library Is Empty Add Books");
                            Console.WriteLine("-----------------------------------");
                        }
                        break;
                    case "2":
                        var new_book = academic_library.CreateNewBook();

                        if (librarian_shaik.AddBook(academic_library, new_book) == true)
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("{0} Book Added Successfully", new_book.name);
                            Console.WriteLine("-----------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Failed To Add {0}", new_book.name);
                            Console.WriteLine("-----------------------------------");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter the Book Name To Delete : ");
                        var book_name = Console.ReadLine();

                        if (librarian_shaik.DeleteBook(academic_library, book_name) == true)
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("{0} Book Deleted Successfully", book_name);
                            Console.WriteLine("-----------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("No Such Book To Delete");
                            Console.WriteLine("-----------------------------------");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Enter the Book Name To Search : ");
                        book_name = Console.ReadLine();

                        var search_result_book = librarian_shaik.SearchBook(academic_library, book_name);
                        if (!(search_result_book is bool))
                        {
                            search_result_book.DisplayDetails();
                        }
                        else
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("{0} Book is not Found in Library", book_name);
                            Console.WriteLine("-----------------------------------");
                        }
                        break;
                    case "5":
                        if(librarian_shaik.DisplayRecentlyAddedBook(academic_library) == false)
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("No Book Added Recently");
                            Console.WriteLine("-----------------------------------");
                        }
                        break;
                    default:
                        goto ExitFromLibrary;
                }
            }
            ExitFromLibrary:
            Console.WriteLine("--------Thanks For Using Library---------");
        }
    }
}
