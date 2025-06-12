using LibraryManagementSystem.Base;
using LibraryManagementSystem.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class Member : User
    {
        public List<Book> BorrowedBooks { get; set; }

        public Member(string name, int id) : base(name, id, UserType.Member)
        {
            this.BorrowedBooks = new List<Book>();
        }

        public override UserType Type
        {
            get { return type; }
            set
            {
                if (type != UserType.Member)
                {
                    throw new Exception("Invalid user type for member.");
                }
            }
        }
    }
}
