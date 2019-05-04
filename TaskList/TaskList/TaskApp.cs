using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList
{
    class TaskApp
    {
        private List<Task> _tasks = new List<Task>();

        public string AddTaskValidator(string taskItem)
        {
            Console.WriteLine($"Enter {taskItem}.");
            string taskItemInput = Console.ReadLine();

            if(taskItemInput == "")
            {
                return AddTaskValidator(taskItem);
            }
            else
            {
                return taskItemInput;
            }
        }

        public void AddTask()
        {
            bool validName = false;
            bool validDescription = false;
            bool validDueDate = false;
            bool validCompleted = false;

            string taskName = "";
            string taskDescription = "";
            bool taskCompleted = false;
            string taskCompletedString = "";

            DateTime taskDueDate = DateTime.MinValue;

            while (! validName)
            {
                Console.WriteLine("Please enter task name: ");
                taskName = Console.ReadLine();
                if (taskName != "")
                {
                    validName = true;
                }
            }

            while (! validDescription)
            {
                Console.WriteLine("Please enter task description: ");
                taskDescription = Console.ReadLine();
                if (taskDescription != "")
                {
                    validDescription = true;
                }
            }

            while (! validDueDate)
            {
                Console.WriteLine("Please enter task due date: ");
                taskDueDate = DateTime.Parse(Console.ReadLine());
                if (taskDueDate != DateTime.MinValue)
                {
                    validDueDate = true;
                }
            }

            while (!validCompleted)
            {
                Console.WriteLine("Is this task completed? (y/n)");
                taskCompletedString = Console.ReadLine();
                if(taskCompletedString == "y" || taskCompletedString == "yes")
                {
                    taskCompleted = true;
                    validCompleted = true;
                }
                else if(taskCompletedString == "n" || taskCompletedString == "no" || taskCompletedString == "")
                {
                    taskCompleted = false;
                    validCompleted = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }

            Task task = new Task(taskName, taskDescription, taskDueDate, taskCompleted);
            _tasks.Add(task);
        }

        public void AddTask(string name, string description, DateTime dueDate)
        {
            Task task = new Task(name, description, dueDate);
            _tasks.Add(task);
        }

        public void ListTasks()
        {
            Console.WriteLine();
            List<string> taskNames = new List<string>();
            //condition ? consequent : alternative
            string yes = "yes";
            string no = "no";
            foreach (Task task in _tasks)

            {
                taskNames.Add($"TASK: {task.Name}, DUE DATE: {task.DueDate}, COMPLETED: {(task.Completed ? yes : no)}, DESCRIPTION: {task.Description}");
            }

            Menu menu = new Menu(taskNames, "TASK NAMES");
            menu.PrintMenu();
        }

        public void DeleteTask()
        {
            ListTasks();

            Console.WriteLine("What task would you like to delete?");
            // int delete = int.Parse(Console.ReadLine());
            int.TryParse(Console.ReadLine(), out int delete);
            Console.Clear();

            if(delete > 0 && delete < (_tasks.Count + 1))
            {               
                // confirm that the user wants to actually delete
                Console.WriteLine("Are you sure you want to delete the task?");
                string answer = Console.ReadLine().ToLower();
                if (answer == "y" || answer == "yes")
                {
                    _tasks.RemoveAt(delete - 1);
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You didn't say yes, so we are assuming no.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid Input. Try again.");
                DeleteTask();
            }
        }

        public void ToggleTaskCompletion()
        {
            Console.WriteLine();
            ListTasks();
            Console.WriteLine("What task is completed?");
            int.TryParse(Console.ReadLine(), out int completed);

            if (completed > 0 && completed < (_tasks.Count + 1))
            {
                Console.WriteLine("Are you sure that task is complete?");
                string answer = Console.ReadLine().ToLower();
                if (answer == "y" || answer == "yes")
                {
                    // Toggle complete/incomplete
                    _tasks[completed - 1].Completed = !_tasks[completed - 1].Completed;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You didn't say yes, so we are assuming no.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Input. Try again.");
                ToggleTaskCompletion();
            }
        }
    }
}
