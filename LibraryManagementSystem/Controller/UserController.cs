using LibraryManagementSystem.Base;
using LibraryManagementSystem.Enum;
using LibraryManagementSystem.Interface;

namespace LibraryManagementSystem.Controller
{
    public class UserController
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public List<BaseUser> GetAllUsers()
        {
            try
            {
                return userService.GetAllUsers();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve users", ex);
            }
        }

        public void AddUser(string name, int id, UserType type)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("User name cannot be empty", nameof(name));
            }

            if (id <= 0)
            {
                throw new ArgumentException("User ID must be positive", nameof(id));
            }

            try
            {
                userService.AddUser(name, id, type);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to create user: {ex.Message}", ex);
            }
        }

        public BaseUser GetUserById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("User ID must be positive", nameof(id));
            }

            try
            {
                var user = userService.GetUserById(id);
                if (user == null)
                {
                    throw new ApplicationException($"No user found with ID: {id}");
                }
                return user;
            }
            catch (Exception ex) when (!(ex is ApplicationException))
            {
                throw new ApplicationException($"Failed to retrieve user with ID: {id}", ex);
            }
        }

        public BaseUser RemoveUser(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("User ID must be positive", nameof(id));
            }

            try
            {
                return userService.RemoveUser(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to remove user with ID: {id}", ex);
            }
        }
    }
}
