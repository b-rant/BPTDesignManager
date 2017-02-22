using RoT_v6.Models;
using System.Collections.Generic;

namespace RoT_v6.ViewModels
{
    public class JobsDetails_JobPurchasesWorkTask
    {
        public Job Job { get; set; }
        public List<Purchase> Purchases { get; set; }
        public List<WorkTask> ActiveTasks { get; set; }
        public List<WorkTask> CompletedTasks { get; set; }
    }
}
