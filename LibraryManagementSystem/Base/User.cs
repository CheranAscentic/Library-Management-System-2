using LibraryManagementSystem.Enum;

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
            get => name;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");
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
    }
}
