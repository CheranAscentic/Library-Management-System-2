using LibraryManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class Staff : IUser
    {
        public string Name { get; private set; }
        public string ID { get; private set; }
        public string Type { get; private set; }

        public Staff(string name, string id, string type)
        {
            Name = name;
            ID = id;
            Type = type;
        }
    }
}
