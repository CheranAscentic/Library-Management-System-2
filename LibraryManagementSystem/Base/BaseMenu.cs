

namespace LibraryManagementSystem.Base
{
    public abstract class BaseMenu
    {
        public BaseMenu() { }
        public abstract bool Display();

        protected string GetInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        }
        protected int GetIntInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                try
                {
                    int number = Convert.ToInt32(input);
                    return number;
                } 
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
        }

        protected int GetIntInput(string prompt, int[] range)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                try
                {
                    int number = Convert.ToInt32(input);
                    if (range.Contains(number))
                    {
                        return number;
                    }
                    else
                    {
                        Console.WriteLine($"Input must be one of the following: {string.Join(", ", range)}. Please try again.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
        }
    }
}
