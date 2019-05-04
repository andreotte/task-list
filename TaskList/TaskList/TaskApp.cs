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

            Console.WriteLine("What task would you like mto delete?");
            int delete = int.Parse(Console.ReadLine());
            Console.Clear();

            // confirm that the user wants to actually delete
            Console.WriteLine("Are you sure???");
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

        public void MarkTaskComplete()
        {
            Console.WriteLine();
            ListTasks();
            Console.WriteLine("What task is completed?");
            int completed = int.Parse(Console.ReadLine());
            _tasks[completed - 1].Completed = ! _tasks[completed - 1].Completed;
        }
    }
}
