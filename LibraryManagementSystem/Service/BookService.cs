using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Service
{
    public class BookService : IBookService
    {
        private List<Book> books;

        public BookService() { 
            this.books = new List<Book>();
        }
        public Book AddBook(string title, string author, int year, string category)
        {
            Book newBook = new Book(title, author, year, category);
            books.Add(newBook);
            return newBook;
        }

        public Book GetBook(string title)
        {
            var book = books.FirstOrDefault(b => b.Title == title);
            if (book == null)
            {
                throw new Exception("Book with Title cannot be found");
            }
            return book;
        }

        public List<Book> GetBooks()
        {
            return new List<Book>(books);
        }

        public Book RemoveBook(string title)
        {
            var book = books.FirstOrDefault(b => b.Title == title);
            if (book == null)
            {
                throw new Exception("Book with Title cannot be found");
            }
            books.Remove(book);
            return book;
        }
    }
}
