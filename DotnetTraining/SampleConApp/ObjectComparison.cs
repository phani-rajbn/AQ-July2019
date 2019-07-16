using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    enum BookComparison {  Title, Price, ID };
    class Book : IComparable<Book>
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }

        public int CompareTo(Book other)
        {
            //1 , 0, -1
            //if (Price < other.Price)
            //    return -1;
            //else if (Price > other.Price)
            //    return 1;
            //else
            //    return 0;
            return Price.CompareTo(other.Price);
        }
    }

    //Comparer is a seperate class whose job is to compare on multi conditions, 
    class BookComparer : IComparer<Book>
    {
        private BookComparison criteria;

        public BookComparer(BookComparison criteria)
        {
            this.criteria = criteria;
        }
        public int Compare(Book b1, Book b2)
        {
            switch (criteria)
            {
                case BookComparison.Title:
                    return b1.Title.CompareTo(b2.Title);
                case BookComparison.Price:
                    return b1.CompareTo(b2);
                case BookComparison.ID:
                    return b1.BookID.CompareTo(b2.BookID);
                default:
                    return 0; ;
            }
        }
    }

    class ObjectComparison
    {
        static void Main(string[] args)
        {
            defaultComparison();
        }

        private static void defaultComparison()
        {
            List<Book> list = new List<Book>();
            list.Add(new Book { BookID = 1, Price = 650, Title = "Professional C#" });
            list.Add(new Book { BookID = 2, Price = 450, Title = "Inside Windows" });
            list.Add(new Book { BookID = 3, Price = 350, Title = "2 States" });
            list.Add(new Book { BookID = 4, Price = 300, Title = "A Suitable Boy" });
            list.Sort(new BookComparer(BookComparison.ID));//Sort internally sorts the collection based on a comparing clause which is specified by a method called Compare. 
            foreach (var book in list)
                Console.WriteLine($"{book.Title} priced at {book.Price}");
        }
    }

}

