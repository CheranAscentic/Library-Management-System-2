using LibraryManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class Member : IUser
    {
        public string Name { get; private set; }
        public string ID { get; private set; }
        public string Type { get; private set; }

        public List<Book> BorrowedBooks { get; set; }
        

        public Member(string name, string ID)
        {
            this.Name = name;
            this.ID = ID;
            this.BorrowedBooks = new List<Book>();
            this.Type = "Member";
        }
    }
}
