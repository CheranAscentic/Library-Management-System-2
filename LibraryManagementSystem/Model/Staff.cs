﻿using LibraryManagementSystem.Base;
using LibraryManagementSystem.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class Staff : User
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
        }
    }
}
