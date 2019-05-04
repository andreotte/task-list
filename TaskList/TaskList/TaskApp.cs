using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList
{
    class TaskApp
    {
        // list of tasks
        private List<Task> _tasks = new List<Task>();

        // make sure strings the user inputs are not empty
        public string TaskValidator(string taskItem)
        {
            Console.WriteLine($"Enter {taskItem}.");
            string taskItemInput = Console.ReadLine();

            if(taskItemInput == "")
            {
                return TaskValidator(taskItem);
            }
            else
            {
                return taskItemInput;
            }
        }

        public void AddTask()
        {
            bool validDueDate = false;
            bool validCompleted = false;
            bool taskCompleted = false;

            DateTime taskDueDate = DateTime.MinValue;

            string taskName = TaskValidator("Task name");
            string taskDescription = TaskValidator("Task description");
            string taskCompletedString = "";

            // make sure user inputs a valid date by checking if taskDueDate has changed from default value
            while (! validDueDate)
            {
                DateTime.TryParse(TaskValidator("Task due date"), out taskDueDate);

                if (taskDueDate != DateTime.MinValue)
                {
                    validDueDate = true;
                    break;
                }
                Console.WriteLine("Invalid input. Please enter as dd/mm/yy");
            }

            // make sure user inputs a valid string for task completion
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

            // create a new task object and add it to the task list
            _tasks.Add(new Task(taskName, taskDescription, taskDueDate, taskCompleted));
        }

        // method overload for importing tasks without completion information
        public void AddTask(string name, string description, DateTime dueDate)
        {
            _tasks.Add(new Task(name, description, dueDate));
        }

        public void ListTasks()
        {
            Console.WriteLine();
            List<string> taskInformation = new List<string>();
            string yes = "yes";
            string no = "no";
            foreach (Task task in _tasks)
            {
                taskInformation.Add($"TASK: {task.Name}, DUE DATE: {task.DueDate}, COMPLETED: {(task.Completed ? yes : no)}, DESCRIPTION: {task.Description}");
            }

            Menu menu = new Menu(taskInformation, "TASK NAMES");
            menu.PrintMenu();
        }

        public void DeleteTask()
        {
            ListTasks();

            Console.WriteLine("What task would you like to delete?");
            int.TryParse(Console.ReadLine(), out int delete);
            Console.Clear();

            // make sure selected task is in range
            if(delete > 0 && delete < (_tasks.Count + 1))
            {               
                // confirm that the user wants to delete the task
                Console.WriteLine("Are you sure you want to delete the task?");
                string answer = Console.ReadLine().ToLower().Trim();
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

        // mark tasks as complete or incomplete
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
                    // toggle complete/incomplete
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
