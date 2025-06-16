using LibraryManagementSystem.Base;
using LibraryManagementSystem.Enum;

namespace LibraryManagementSystem.Model
{
    public class Staff : BaseUser
    {
        public Staff(string name, int id, UserType type) : base(name, id, type) { }

        public override UserType Type
        {
            get { return type; }
            set
            {
                UserType[] validTypes = { UserType.StaffMinor, UserType.StaffManagement };

                if (!validTypes.Contains(value) || value == null)
                {
                    throw new Exception("Invalid user type for Staff.");
                }
                type = value;
            }
        }
    }
}
