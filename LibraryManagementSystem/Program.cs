using LibraryManagementSystem.Model;
using LibraryManagementSystem.Enum;
using LibraryManagementSystem.Core;
using LibraryManagementSystem.Base;
using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Service;
using LibraryManagementSystem.Menu;

namespace LibraryManagementSystem;

public class Program
{
    public static void Main(string[] args)
    {
        /*Library library = new Library();

        library.AddBook(new Book("1984", "George Orwell", 2010, "History"));
        library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", 2015, "Fiction"));

        Member member = new Member("Alice", 1);

        library.AddUser(member);
        library.AddUser(new Member("Bob", 2));
        library.AddUser(new Staff("Charlie", 3, UserType.StaffMinor));
        library.AddUser(new Staff("Diana", 4, UserType.StaffManagement));*/

        
        

        BookService bookService = new BookService();
        bookService.AddBook("1984", "George Orwell", 2010, "History");
        bookService.AddBook("To Kill a Mockingbird", "Harper Lee", 2015, "Fiction");

        UserService userService = new UserService();
        userService.AddUser("Alice", 1, UserType.Member);
        userService.AddUser("Bob", 2, UserType.Member);
        userService.AddUser("Charlie", 3, UserType.StaffMinor);
        userService.AddUser("Diana", 4, UserType.StaffManagement);

        LoginMenu loginMenu = new LoginMenu(userService);
        MainMenu mainMenu = new MainMenu(bookService, userService);

        Library library = new Library(bookService, userService, loginMenu, mainMenu);

        library.start();

    }
}
