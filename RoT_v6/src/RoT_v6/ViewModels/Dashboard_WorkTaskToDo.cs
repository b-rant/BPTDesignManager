using RoT_v6.Models;
using System.Collections.Generic;

namespace RoT_v6.ViewModels
{
    public class Dashboard_WorkTaskToDo
    {
        public List<ToDo> ToDos { get; set; }
        public List<WorkTask> CompletedTasks { get; set; }
        public List<WorkTask> ActiveTasks { get; set; }
    }
}
