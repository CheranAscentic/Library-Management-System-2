using LibraryManagementSystem.Base;
using LibraryManagementSystem.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interface
{
    public interface IUserService
    {
        public void AddUser(string name, int id, UserType type);
        public BaseUser RemoveUser(int id);
        public BaseUser GetUserById(int id);
        public List<BaseUser> GetAllUsers();
    }
}
