using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RoT_v6.Models
{
    public enum JobStatus
    {
        Active,
        NotReady,
        Completed,
    }

    public class Job
    {

        public int JobID { get; set; }
        [Display(Name = "Job Number")]
        public string jobNum { get; set; }
        public string Client { get; set; }
        public string Description { get; set; }
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }
        [Display(Name = "Desired Delivery")]
        public string DesiredDate { get; set; }
        [Display(Name = "Completion Date")]
        public string CompleteDate { get; set; }
        [Display(Name = "Estimated Cost")]
        public float EstCost { get; set; }
        [Display(Name = "Invested Cost")]
        public float InvCost { get; set; }
        public JobStatus Status { get; set; }
        [Display(Name = "Estimated Hours")]
        public int EstHours { get; set; }
        [Display(Name = "Invested Hours")]
        public int InvHours { get; set; }

    }
}
