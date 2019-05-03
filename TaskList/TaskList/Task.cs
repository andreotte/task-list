using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList
{
    class Task
    {
        // declare global vars and Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }

        // Constructor
        public Task(string Name, string Description, DateTime DueDate, bool Completed)
        {
            this.Name = Name;
            this.Description = Description;
            this.DueDate = DueDate;
            this.Completed = Completed;
        }

        public Task(string Name, string Description, DateTime DueDate)
        {
            this.Name = Name;
            this.Description = Description;
            this.DueDate = DueDate;
        }
    }
}
