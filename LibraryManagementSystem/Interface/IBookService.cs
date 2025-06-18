using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interface
{
    public interface IBookService
    {
        public Book AddBook(string title, string author, int year, string category);
        public Book GetBook(string title);
        public List<Book> GetBooks();
        public Book RemoveBook(string title);

    }
}
