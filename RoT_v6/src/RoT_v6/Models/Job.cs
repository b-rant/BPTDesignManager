using System.Collections.Generic;
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
        public string jobNum { get; set; }
        public string Client { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string DesiredDate { get; set; }
        public string CompleteDate { get; set; }
        public float EstCost { get; set; }
        public float InvCost { get; set; }
        public JobStatus Status { get; set; }
        public int EstHours { get; set; }
        public int InvHours { get; set; }

    }
}
