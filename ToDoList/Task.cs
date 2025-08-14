using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Task
    {
        string taskHeader;
        int priority;
        string description;

        public Task(string TaskName, int Priorityparam, string Descriptionparam) 
        {
            taskHeader = TaskName;
            priority = Priorityparam;
            description = Descriptionparam;
        }

        public string TaskHeader {
        get { return taskHeader; } set { taskHeader = value; }
        }

        public int Priority { get {return priority;} set { priority = value; } }

        public string Description { get { return description;} set { description = value; } }

        public override string ToString()
        {
            return $"Priority: {Priority.ToString()} {TaskHeader.ToString()} Desc: {description}";
        }
    }
}
