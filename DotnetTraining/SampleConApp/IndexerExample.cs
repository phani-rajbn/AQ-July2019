using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class BookCollection : IEnumerable<Book>
    {
        List<Book> _books = new List<Book>();
        public void AddBook(Book b1) => _books.Add(b1);
        public List<Book> GetAllBooks() => _books;

        public IEnumerator<Book> GetEnumerator()
        {
            return ((IEnumerable<Book>)_books).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Book>)_books).GetEnumerator();
        }

        public int Size => _books.Count;
        //Indexer is [] being overloaded....
        public Book this[int index] => _books[index];
        public Book this[string title] => _books.Find((b)=>b.Title == title);
        //{
        //    get
        //    {
        //        foreach(var b in _books)
        //        {
        //            if (b.Title == title)
        //                return b;
        //        }
        //        return null;
        //    }
        //}

    }
    class IndexerExample
    {
        static void Main(string[] args)
        {
            BookCollection col = new BookCollection();
            col.AddBook(new Book { BookID = 1, Price = 650, Title = "Professional C#" });
            col.AddBook(new Book { BookID = 2, Price = 450, Title = "Inside Windows" });
            col.AddBook(new Book { BookID = 3, Price = 350, Title = "2 States" });
            col.AddBook(new Book { BookID = 4, Price = 300, Title = "A Suitable Boy" });
            for (int i = 0; i < col.Size; i++)
            {
                Console.WriteLine(col[i].Title);
            }

            foreach(var book in col)
            {
                Console.WriteLine(col[book.Title].Price);
            }
        }
    }
}
