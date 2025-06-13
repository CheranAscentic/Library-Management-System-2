using LibraryManagementSystem.Base;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Enum;
using LibraryManagementSystem.Interface;

namespace LibraryManagementSystem.Core
{
    public class Library
    {
        private IBookService bookService;
        private IUserService userService;
        private BaseMenu loginMenu;
        private BaseMenu mainMenu;

        public Library(IBookService bookService, IUserService userService, BaseMenu loginMenu, BaseMenu mainMenu)
        {
            this.bookService = bookService;
            this.userService = userService;
            this.loginMenu = loginMenu;
            this.mainMenu = mainMenu;
        }

        public void start() 
        {
            while (loginMenu.Display())
            {
                while (mainMenu.Display()) { }
            }
        }


    }
}
