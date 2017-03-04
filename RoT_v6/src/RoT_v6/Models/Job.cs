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

        [Required]
        public string jobNum { get; set; }

        [Required]
        public string Client { get; set; }

        [Required]
        public string Description { get; set; }

        
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        [Required]
        [Display(Name = "Desired Delivery")]
        public string DesiredDate { get; set; }

       
        [Display(Name = "Completion Date")]
        public string CompleteDate { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F2}")]
        [Required]
        [Display(Name = "Estimated Cost")]
        public decimal EstCost { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F2}")]
        [Display(Name = "Invested Cost")]
        public decimal InvCost { get; set; }

        
        public JobStatus Status { get; set; }

        [Required]
        [Display(Name = "Estimated Hours")]
        public int EstHours { get; set; }


        [Display(Name = "Invested Hours")]
        public int InvHours { get; set; }

    }
}
