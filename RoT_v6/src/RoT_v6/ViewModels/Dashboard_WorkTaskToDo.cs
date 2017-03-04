using RoT_v6.Models;
using System.Collections.Generic;

namespace RoT_v6.ViewModels
{
    public class Dashboard_WorkTaskToDo
    {

        public List<WorkTask> CompletedTasks { get; set; }
        public List<WorkTask> ActiveTasks { get; set; }
        public List<ToDo> EmpToDo { get; set; }
        public List<ApplicationUser> User { get; set; }
    }
}
