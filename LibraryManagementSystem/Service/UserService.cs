using LibraryManagementSystem.Base;
using LibraryManagementSystem.Enum;
using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem.Service
{
    public class UserService : IUserService
    {

        private List<BaseUser> users;

        public UserService() { 
            this.users = new List<BaseUser>();
        }
        public void AddUser(string name, int id, UserType type)
        {
            BaseUser newUser;

            foreach (var each in users)
            {
                if (each.Id == id)
                {
                    throw new Exception("User with ID already exists");
                }
            }

            switch (type)
            {
                case UserType.Member:
                    newUser = new Member(name, id);
                    break;
                case UserType.StaffMinor:
                    newUser = new Staff(name, id, type);
                    break;
                case UserType.StaffManagement:
                    newUser = new Staff(name, id, type);
                    break;
                default:
                    throw new ArgumentException("Invalid user type");
            }

            users.Add(newUser);
        }

        public List<BaseUser> GetAllUsers()
        {
            return new List<BaseUser>(users);
        }

        public BaseUser GetUserById(int id)
        {
            foreach (var each in users)
            {
                if (each.Id == id)
                {
                    return each;
                }
            }
            throw new Exception("User with ID canot be found");
        }

        public BaseUser RemoveUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("User with Id cannot be found");
            }
            users.Remove(user);
            return user;
        }
    }
}
