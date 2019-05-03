using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList
{
    class Menu
    {
        public int MenuItem { get; }
        public List<string> MenuItems { get; }

        public Menu(List<string> MenuItems)
        {
            this.MenuItems = MenuItems;
        }

        public void PrintMenu()
        {
            for(int i = 1; i < (MenuItems.Count + 1); i++)
            {
                Console.WriteLine($"{i}) {MenuItems[i - 1]} ");
            }
        }

        public int GetUserInput()
        {
            Console.WriteLine("enter a number");
            int.TryParse(Console.ReadLine(), out int userInput);

            //try
            //{
            //    int.Parse(userInput);
            //}
            //catch (Exception)
            //{

            //    Console.WriteLine("invalid input");
            //    GetUserInput();
            //}

            if ( userInput < 1 || userInput > MenuItems.Count)
            {
                Console.WriteLine("invalid input");
                return GetUserInput();
            }
            else
            {
                return userInput;
            }
        }
    }
}
