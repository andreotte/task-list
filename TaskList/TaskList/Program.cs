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
            List<string> menuItems = new List<string> { "List tasks", "Add task", "Delete task", "Mark task complete", "Quit" };
            Menu menu = new Menu(menuItems);
            menu.PrintMenu();
            TaskApp printTasks = new TaskApp();
            printTasks.AddTask("make bed", "make bed really well", DateTime.Now);
            printTasks.AddTask("bootcamp", "write kick-ass code", DateTime.Today);
            printTasks.AddTask("dinner", "cook noodles", DateTime.Now);


            bool run = true;
            while (run)
            {
                int userInput = menu.GetUserInput();

                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        printTasks.ListTasks();
                        break;
                    case 2:
                        Console.WriteLine("Please enter task name: ");
                        string taskName = Console.ReadLine();
                        Console.WriteLine("Please enter task description: ");
                        string taskDescription = Console.ReadLine();
                        Console.WriteLine("Please enter task due date: ");
                        DateTime taskDueDate = DateTime.Parse(Console.ReadLine());
                        printTasks.AddTask(taskName, taskDescription, taskDueDate);
                        break;
                    case 3:
                        printTasks.DeleteTask();
                        Console.Clear();
                        menu.PrintMenu();
                        break;
                    case 4:
                        printTasks.MarkTaskComplete();
                        Console.Clear();
                        menu.PrintMenu();
                        break;
                    case 5:
                        Console.WriteLine("Are you sure you want to quit?");
                        string answer = Console.ReadLine();
                        if (answer == "y" || answer == "yes")
                        {
                            run = false;
                        }
                        else
                        {
                            Console.WriteLine("You didn't say yes, so we are assuming no.");
                        }
                        break;
                }
            }


        }
    }
}
