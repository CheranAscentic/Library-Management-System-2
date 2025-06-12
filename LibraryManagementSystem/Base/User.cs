using LibraryManagementSystem.Enum;
using LibraryManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Base
{
    public abstract class User
    {
        private string name;
        private int id;
        protected UserType type;

        public User(string name, int id, UserType userType)
        {
            this.Name = name;
            this.Id = id;
            this.Type = userType;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Equals(null))
                {
                    throw new Exception("Name cannot be null.");
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty.");
                }
                name = value;
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("ID must be a positive integer.");
                }
                id = value;
            }
        }

        public abstract UserType Type 
        {
            get; 
            set;
        }
        /*{
            get { return type; }
            set
            {
                UserType[] validTypes = { UserType.Member, UserType.StaffMinor, UserType.StaffManagement };
                
                if (value.Equals(null))
                {
                    throw new Exception("UserType cannot be null."); 
                }
                else if (!validTypes.Contains(value))
                {
                    throw new Exception("User cannot be of this UserType");
                }
                type = value;
            }
        }*/


    }
}
