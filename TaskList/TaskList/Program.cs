using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList
{
    class Program
    {
        // list of task objects
        public static List<Task> tasks = new List<Task>();

        static void Main(string[] args)
        {
            // list of main menu items
            List<string> menuItems = new List<string> { "List tasks", "Add task", "Delete task", "Mark task complete", "Quit" };
            Menu menu = new Menu(menuItems, "MAIN MENU");
            menu.PrintMenu();
            TaskApp taskApp = new TaskApp();
            // add some dummy tasks to the list
            taskApp.AddTask("make bed", "make bed really well", DateTime.Now);
            taskApp.AddTask("bootcamp", "write kick-ass code", DateTime.Today);
            taskApp.AddTask("dinner", "cook noodles", DateTime.Now);

            bool run = true;
            while (run)
            {
                // ask the user to choose the action they would like to perform based on the main menu items
                int userInput = menu.GetUserInput();

                switch (userInput)
                {
                    case 1: // List Tasks
                        Console.Clear();
                        taskApp.ListTasks();
                        menu.PrintMenu();
                        break;
                    case 2: // Add Task
                        taskApp.AddTask();
                        Console.Clear();
                        menu.PrintMenu();
                        break;
                    case 3: // Delete Task
                        taskApp.DeleteTask();
                        menu.PrintMenu();
                        break;
                    case 4: // Toggle Task Completion
                        Console.Clear();
                        taskApp.ToggleTaskCompletion();
                        Console.Clear();
                        menu.PrintMenu();
                        break;
                    case 5: // Quit
                        Console.WriteLine("Are you sure you want to quit?");
                        string answer = Console.ReadLine();
                        Console.Clear();

                        if (answer == "y" || answer == "yes")
                        {
                            run = false;
                        }
                        else
                        {
                            Console.WriteLine("You didn't say yes, so we are assuming no.");
                            Console.WriteLine();
                            menu.PrintMenu();
                        }
                        break;
                }
            }
        }
    }
}
