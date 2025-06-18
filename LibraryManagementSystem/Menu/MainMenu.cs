using LibraryManagementSystem.Base;
using LibraryManagementSystem.Enum;
using LibraryManagementSystem.Interface;
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Menu
{
    public class MainMenu : BaseMenu
    {
        private readonly IBookService bookService;
        private readonly IUserService userService;

        public MainMenu(IBookService bookService, IUserService userService) : base()
        {
            this.bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public override bool Display()
        {
            string prompt = "=== Main Menu ===\n" +
                            "1. View All Books\n" +
                            "2. Add Book\n" +
                            "3. Remove Book\n" +
                            "4. View All Users\n" +
                            "5. Add User\n" +
                            "6. Remove User\n" +
                            "7. Exit to Login\n" +
                            "8. Exit Library Management System.\n";
            int[] options = { 1, 2, 3, 4, 5, 6, 7, 8 };

            switch (GetIntInput(prompt, options))
            {
                case 1:
                    Console.WriteLine("1. View All Books\n");
                    ViewAllBooks();
                    break;
                case 2:
                    Console.WriteLine("2. Add Book\n");
                    AddBook();
                    break;
                case 3:
                    Console.WriteLine("3. Remove Book\n");
                    RemoveBook();
                    break;
                case 4:
                    Console.WriteLine("4. View All Users\n");
                    ViewAllUsers();
                    break;
                case 5:
                    Console.WriteLine("5. Add User\n");
                    AddUser();
                    break;
                case 6:
                    Console.WriteLine("6. Remove User\n");
                    RemoveUser();
                    break;
                case 7:
                    Console.WriteLine("7. Exit\n");
                    return false;
                case 8:
                    Console.WriteLine("8. Exit Library Management System.\n");
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.\n");
                    break;
            }
            return true;
        }

        private void ViewAllBooks()
        {
            var books = bookService.GetBooks();
            if (books.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }
            Console.WriteLine("Books:");
            foreach (var book in books)
            {
                Console.WriteLine($"- {book.Title} by {book.Author} ({book.PublicationYear}) [{book.Category}] {(book.Available ? "Available" : "Borrowed")}");
            }
        }

        private void AddBook()
        {
            string title = GetInput("Enter book title: ");
            string author = GetInput("Enter author: ");
            int year = GetIntInput("Enter publication year: ");
            string category = GetInput("Enter category: ");
            try
            {
                var book = bookService.AddBook(title, author, year, category);
                Console.WriteLine($"Book '{book.Title}' added.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void RemoveBook()
        {
            string title = GetInput("Enter the title of the book to remove");
            try
            {
                var book = bookService.RemoveBook(title);
                Console.WriteLine($"Book '{book.Title}' removed.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error removing book: {e.Message}");
            }
        }

        private void ViewAllUsers()
        {
            try
            {
                var users = userService.GetAllUsers();
                if (users.Count == 0)
                {
                    Console.WriteLine("No users found.");
                    return;
                }
                Console.WriteLine("Users:");
                foreach (var user in users)
                {
                    Console.WriteLine($"- {user.Name} (ID: {user.Id}, Type: {user.Type})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error viewing users: {ex.Message}");
            }
        }

        private void AddUser()
        {
            try
            {
                string name = GetInput("Enter user name");
                int id = GetIntInput("Enter user ID");

                string userTypePrompt = "Select user type:\n1. Member\n2. StaffMinor\n3. StaffManagement\n";
                int[] userTypeOptions = { 1, 2, 3 };
                UserType type = GetIntInput(userTypePrompt, userTypeOptions) switch
                {
                    1 => UserType.Member,
                    2 => UserType.StaffMinor,
                    3 => UserType.StaffManagement,
                    _ => throw new ArgumentException("Invalid user type selected")
                };

                userService.AddUser(name, id, type);
                Console.WriteLine($"User '{name}' added as {type}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create a new user: {ex.Message}");
            }
        }

        private void RemoveUser()
        {
            try
            {
                int id = GetIntInput("Enter the ID of the user to remove");
                var user = userService.RemoveUser(id);
                Console.WriteLine($"User {user.Name} removed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
