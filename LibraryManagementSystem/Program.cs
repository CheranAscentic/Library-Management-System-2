using LibraryManagementSystem.Model;
using LibraryManagementSystem.Service;
using LibraryManagementSystem.Enum;

namespace LibraryManagementSystem;

public class Program
{
    public static void Main(string[] args)
    {
        Library library = new Library();

        library.AddBook(new Book("1984", "George Orwell", 2010, "History"));
        library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", 2015, "Fiction"));

        Member member = new Member("Alice", 1);

        library.AddUser(member);
        library.AddUser(new Member("Bob", 2));
        library.AddUser(new Staff("Charlie", 3, UserType.StaffMinor));
        library.AddUser(new Staff("Diana", 4, UserType.StaffManagement));

        while (true)
        {
            Console.WriteLine("\nLibrary Menu:");
            Console.WriteLine("1. Borrow Book");
            Console.WriteLine("2. Return Book");
            Console.WriteLine("3. Display Books");
            Console.WriteLine("4. Display Users");
            Console.WriteLine("5. Exit");

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    library.BorrowBook(library.GetBookByTitle("1984"), member);
                    break;
                case 2:
                    library.ReturnBook(library.GetBookByTitle("1984"), member);
                    break;
                case 3:
                    library.DisplayBooks(member);
                    break;
                case 4:
                    library.DisplayUsers();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

    }
}
