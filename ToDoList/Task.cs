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

        public Task(string TaskName) 
        {
            TaskHeader = TaskName;
        }

        public override string ToString()
        {
            return TaskHeader.ToString();
        }
    }
}
