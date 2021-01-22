using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicLibrary
{
    class Book
    {
        private readonly dynamic author_name, category;
        public dynamic name;
        public int price;
        public Book(dynamic name, dynamic author_name, dynamic category, int price)
        {
            this.name = name;
            this.author_name = author_name;
            this.category = category;
            this.price = price;
        }
        public void DisplayDetails()
        {
            Console.WriteLine("-----------Book Details-------------");
            Console.WriteLine("BookName - {0}", this.name);
            Console.WriteLine("AuthorName - {0}", this.author_name);
            Console.WriteLine("Category - {0}", this.category);
            Console.WriteLine("Price - {0}", this.price);
            Console.WriteLine("------------------------------------");
        }
    }
}
