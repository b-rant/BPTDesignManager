using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RoT_v6.Models
{
    public enum TaskStatus
    {
        Created,
        Pause,
        InProgress,
        Completed
    }

    public class WorkTask
    {
        [Key]
        public int TaskID { get; set; }
        public int JobID { get; set; }
        public string Description { get; set; }
        public string Employee { get; set; }
        public string StartDate { get; set; }
        public string CompleteDate { get; set; }
        public TaskStatus Status { get; set; }
        public double StartTime { get; set; }
        public double TotalTime { get; set; }
        public bool Block { get; set; }
        public string Notes { get; set; }
        public string partNum { get; set; }

    }
}
