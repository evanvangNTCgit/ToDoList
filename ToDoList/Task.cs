using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Task
    {
        string TaskHeader;
        int Priority;
        string Description;

        public Task(string TaskName, int Priorityparam, string Descriptionparam) 
        {
            TaskHeader = TaskName;
            Priority = Priorityparam;
            Description = Descriptionparam;
        }

        public override string ToString()
        {
            return TaskHeader.ToString();
        }
    }
}
