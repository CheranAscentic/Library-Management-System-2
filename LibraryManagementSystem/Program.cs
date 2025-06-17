using LibraryManagementSystem.Core;
using LibraryManagementSystem.Enum;
using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Menu;
using LibraryManagementSystem.Service;

namespace LibraryManagementSystem;

public class Program
{
    public static void Main(string[] args)
    {   
        try {
            IBookService bookService = new BookService();
            IUserService userService = new UserService();
            
            /*BookController bookController = new BookController(bookService);
            UserController userController = new UserController(userService);*/
            
            AddSampleData(bookService, userService);
            
            LoginMenu loginMenu = new LoginMenu(userService);
            MainMenu mainMenu = new MainMenu(bookService, userService);

            Library library = new Library(loginMenu, mainMenu);

            library.Start();
        } 
        catch(Exception ex) {
            Console.WriteLine($"System failed to start: {ex.Message}");
        }
    }
    
    private static void AddSampleData(IBookService bookService, IUserService userService)
    {
        bookService.AddBook("1984", "George Orwell", 2010, "History");
        bookService.AddBook("To Kill a Mockingbird", "Harper Lee", 2015, "Fiction");
        
        userService.AddUser("Alice", 1, UserType.Member);
        userService.AddUser("Bob", 2, UserType.Member);
        userService.AddUser("Charlie", 3, UserType.StaffMinor);
        userService.AddUser("Diana", 4, UserType.StaffManagement);
    }
}
