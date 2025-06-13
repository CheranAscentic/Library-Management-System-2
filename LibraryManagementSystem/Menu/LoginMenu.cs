using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Base;
using LibraryManagementSystem.Enum;

namespace LibraryManagementSystem.Menu
{
    public class LoginMenu : BaseMenu
    {
        IUserService userService;
        public LoginMenu(IUserService userService) : base() {
            this.userService = userService;
        }
        public override bool Display()
        {
            string prompt =
                "=== Login to Library management System ===\n" +
                "\n" +
                "1. User Login\n" +
                "2. Create New User\n" +
                "3. Exit\n";

            int[] options = { 1, 2, 3 };

            switch (GetIntInput(prompt, options))
            {
                case 1:
                    Console.WriteLine("1. User Login");
                    UserLogin();
                    return true; // Continue to the next menu after login
                    break;

                case 2:
                    Console.WriteLine("2. Create New User");
                    CreateNewUser();
                    return true;
                    break;

                case 3:
                    Console.WriteLine("3. Exit");
                    return false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            return true;
        }

        private void UserLogin()
        {
            int userId = GetIntInput("Enter User ID: ");
            BaseUser user = userService.GetUserById(userId);
            if (user == null)
            {
                Console.WriteLine("User not found. Please try again.");
                return;
            }
            Console.WriteLine($"Welcome {user.Name} ({user.Type})");
        }

        private void CreateNewUser()
        {
            int userId = GetIntInput("Enter User ID: ");
            string userName = GetInput("Enter User Name: ");

            string prompt = "Select User Type:\n" +
                "1. Member\n" +
                "2. Staff (Minor)\n" +
                "3. Staff (Management)\n";
            int[] userTypes = { 1, 2, 3 };

            UserType type = GetIntInput(prompt, userTypes) switch
            {
                1 => UserType.Member,
                2 => UserType.StaffMinor,
                3 => UserType.StaffManagement,
                _ => throw new ArgumentException("Invalid user type selected.")
            };

            userService.AddUser(userName, userId, type);
            Console.WriteLine("New User Created");
        }
    }
}
