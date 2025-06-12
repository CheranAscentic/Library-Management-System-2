using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interface
{
    public interface IUser
    {
        string Name { get; set; }
        string Id { get; set; }
        string Type { get; set; }

    }
}
