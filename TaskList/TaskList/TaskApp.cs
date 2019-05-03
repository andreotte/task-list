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

        //public TaskApp(List<Task> tasks)
        //{
        //    _tasks = tasks;
        //}

        public void AddTask(string name, string description, DateTime dueDate)
        {
            Task task = new Task(name, description, dueDate);
            _tasks.Add(task);
        }

        public void ListTasks()
        {
            List<string> taskNames = new List<string>();
            //condition ? consequent : alternative
            string yes = "yes";
            string no = "no";
            foreach (Task task in _tasks)


            {
                taskNames.Add($"{task.Name}, {task.Description}, {task.DueDate}, {(task.Completed ? yes : no)}");
            }

            Menu menu = new Menu(taskNames);
            menu.PrintMenu();
        }

        public void DeleteTask()
        {
            ListTasks();
            Console.WriteLine("What task would you like mto delete?");
            int delete = int.Parse(Console.ReadLine());

            // confirm that the user wants to actually delete
            Console.WriteLine("Are you sure???");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y" || answer == "yes")
            {
                _tasks.RemoveAt(delete - 1);
            }
            else
            {
                Console.WriteLine("You didn't say yes, so we are assuming no.");

            }
        }

        public void MarkTaskComplete()
        {
            ListTasks();
            Console.WriteLine("What task is completed?");
            int completed = int.Parse(Console.ReadLine());
            _tasks[completed - 1].Completed = ! _tasks[completed - 1].Completed;

            //bool andre = true;
            //andre = !andre;


        }

    }
}
