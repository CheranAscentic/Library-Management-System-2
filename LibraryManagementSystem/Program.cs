using LibraryManagementSystem.Core;
using LibraryManagementSystem.Enum;
using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Menu;
using LibraryManagementSystem.Service;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem;

public class Program
{
    public static void Main(string[] args)
    {   
        try
        {
            // Create service collection
            var services = new ServiceCollection();

            // Register services (singleton = one instance for the app lifetime)
            services.AddSingleton<IBookService, BookService>();
            services.AddSingleton<IUserService, UserService>();

            // Register menus (transient = new instance each time requested)
            services.AddTransient<LoginMenu>();
            services.AddTransient<MainMenu>();

            // Register the Library class
            services.AddTransient<Library>(provider => new Library(
                provider.GetRequiredService<LoginMenu>(),
                provider.GetRequiredService<MainMenu>()
            ));

            // Build service provider
            using ServiceProvider serviceProvider = services.BuildServiceProvider();

            // Add sample data
            AddSampleData(
                serviceProvider.GetRequiredService<IBookService>(),
                serviceProvider.GetRequiredService<IUserService>()
            );

            // Get and start the library
            var library = serviceProvider.GetRequiredService<Library>();
            library.Start();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"System failed to start: {ex.Message}");
        }
        /*try {
            IBookService bookService = new BookService();
            IUserService userService = new UserService();
            
            *//*BookController bookController = new BookController(bookService);
            UserController userController = new UserController(userService);*//*
            
            AddSampleData(bookService, userService);
            
            LoginMenu loginMenu = new LoginMenu(userService);
            MainMenu mainMenu = new MainMenu(bookService, userService);

            Library library = new Library(loginMenu, mainMenu);

            library.Start();
        } 
        catch(Exception ex) {
            Console.WriteLine($"System failed to start: {ex.Message}");
        }*/
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
