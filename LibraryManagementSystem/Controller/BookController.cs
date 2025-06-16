using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Controller
{
    public class BookController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public List<Book> GetBooks()
        {
            try
            {
                return bookService.GetBooks();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new ApplicationException("Failed to retrieve books", ex);
            }
        }

        public Book AddBook(string title, string author, int year, string category)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Book title cannot be empty", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Book author cannot be empty", nameof(author));
            }

            if (year < 1000 || year > 2025)
            {
                throw new ArgumentException($"Publication year must be between 1000 and {DateTime.Now.Year + 1}", nameof(year));
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException("Book category cannot be empty", nameof(category));
            }

            try
            {
                return bookService.AddBook(title, author, year, category);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to add book: {ex.Message}", ex);
            }
        }

        public Book GetBookByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Book title cannot be empty", nameof(title));
            }

            try
            {
                return bookService.GetBook(title);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to retrieve book with title '{title}'", ex);
            }
        }

        public Book RemoveBook(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Book title cannot be empty", nameof(title));
            }

            try
            {
                return bookService.RemoveBook(title);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to remove book with title '{title}'", ex);
            }
        }

    }
}