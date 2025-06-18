using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.SystemException
{
    public class ExitApplicationException : Exception
    {
        public ExitApplicationException() : base("User requested application exit.") { }
        public ExitApplicationException(string message) : base(message) { }
    }
}
