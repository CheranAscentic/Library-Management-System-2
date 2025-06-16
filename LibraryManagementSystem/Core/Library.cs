using LibraryManagementSystem.Base;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Enum;
using LibraryManagementSystem.Interface;
using LibraryManagementSystem.SystemException;
using LibraryManagementSystem.Controller;

namespace LibraryManagementSystem.Core
{
    public class Library
    {
        private BookController bookController;
        private UserController userController;
        private BaseMenu loginMenu;
        private BaseMenu mainMenu;

        public Library(BookController bookController, UserController userController, BaseMenu loginMenu, BaseMenu mainMenu)
        {
            this.bookController = this.bookController;
            this.userController = this.userController;
            this.loginMenu = loginMenu;
            this.mainMenu = mainMenu;
        }

        public void start() 
        {
            try
            {
                while (true)
                {
                    while (loginMenu.Display()) { }
                    Console.WriteLine("");
                    while (mainMenu.Display()) { }
                }
            }

            catch (ExitApplicationException ex)
            {
                Console.WriteLine("Exiting application: " + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return;
            }
        }


    }
}
