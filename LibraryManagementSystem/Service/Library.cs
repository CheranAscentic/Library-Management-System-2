using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Service
{
    public class Library
    {
        private List<Book> books = new List<Book>();
        private List<IUser> users = new List<IUser>();

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Book '{book.Title}' added.");
        }

        public void RemoveBook(Book book)
        {
            if (books.Remove(book))
                Console.WriteLine($"Book '{book.Title}' removed.");
            else
                Console.WriteLine("Book not found.");
        }

        public void BorrowBook(Book book, Member member)
        {
            if (!book.Available)
            {
                Console.WriteLine("Book is not available.");
                return;
            }

            book.Available = false;
            member.BorrowedBooks.Add(book);
            Console.WriteLine($"{member.Name} borrowed '{book.Title}'.");
        }

        public void ReturnBook(Book book, Member member)
        {
            book.Available = true;
            member.BorrowedBooks.Remove(book);
            Console.WriteLine($"{member.Name} returned '{book.Title}'.");
        }

        public void DisplayBooks(IUser user)
        {
            if (user.Type.ToLower().Contains("member") || user.Type.ToLower().Contains("management"))
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title} by {book.Author} - {(book.Available ? "Available" : "Borrowed")}");
                }
            }
            else
            {
                Console.WriteLine("Access denied.");
            }
        }

        public void DisplayUsers()
        {
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name} ({user.Type})");
            }
        }

        public void AddUser(IUser user)
        {
            users.Add(user);
            Console.WriteLine($"Member '{user.Name}' added.");
        }

        public Book GetBookByTitle(string title)
        {
            return books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
    }

}
