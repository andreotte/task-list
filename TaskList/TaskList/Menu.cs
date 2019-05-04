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
        public string MenuTitle { get; }

        public Menu(List<string> MenuItems, string MenuTitle)
        {
            this.MenuItems = MenuItems;
            this.MenuTitle = MenuTitle;
        }

        public void PrintMenu()
        {
            Console.WriteLine(MenuTitle);
            for(int i = 1; i < (MenuItems.Count + 1); i++)
            {
                Console.WriteLine($"{i}) {MenuItems[i - 1]}");
            }
            Console.WriteLine();
        }

        public int GetUserInput()
        {
            Console.WriteLine("Select a menu item.");
            int.TryParse(Console.ReadLine(), out int userInput);
            Console.Clear();
            Console.WriteLine();

            if ( userInput < 1 || userInput > MenuItems.Count)
            {
                Console.WriteLine("Invalid Input. Try again.");
                PrintMenu();
                return GetUserInput();
            }
            else
            {
                return userInput;
            }
        }
    }
}
