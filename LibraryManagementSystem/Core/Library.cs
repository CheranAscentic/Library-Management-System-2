using LibraryManagementSystem.Base;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Enum;
using LibraryManagementSystem.Interface;
using LibraryManagementSystem.SystemException;
//using LibraryManagementSystem.Controller;

namespace LibraryManagementSystem.Core
{
    public class Library
    {
        //BaseMenu is an abstract Class
        private readonly BaseMenu loginMenu;
        private readonly BaseMenu mainMenu;

        public Library(BaseMenu loginMenu, BaseMenu mainMenu)
        {
            this.loginMenu = loginMenu ?? throw new ArgumentNullException(nameof(loginMenu));
            this.mainMenu = mainMenu ?? throw new ArgumentNullException(nameof(mainMenu));
        }

        /// <summary>
        /// 
        public void Start() 
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
