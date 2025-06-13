using LibraryManagementSystem.Base;
using LibraryManagementSystem.Enum;

namespace LibraryManagementSystem.Model
{
    public class Staff : BaseUser
    {
        public Staff(string name, int id, UserType type) : base(name, id, type)
        {
            if (type != UserType.StaffMinor && type != UserType.StaffManagement)
            {
                throw new Exception("Invalid user type for staff.");
            }
        }

        public override UserType Type
        {
            get { return type; }
            set
            {
                UserType[] validTypes = { UserType.StaffMinor, UserType.StaffManagement };

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
        }
    }
}
