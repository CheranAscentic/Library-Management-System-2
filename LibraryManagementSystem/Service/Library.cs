using LibraryManagementSystem.Base;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Enum;
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
        private List<User> users = new List<User>();

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

        public void DisplayBooks(User user)
        {
            if (user.Type == UserType.Member || user.Type == UserType.StaffManagement)
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

        public void AddUser(User user)
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
