﻿using System;
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
        [Display(Name = "In Progress")]
        InProgress,
        Completed
    }

    public class WorkTask
    {
        [Key]
        public int TaskID { get; set; }

        public int JobID { get; set; }

        [Required]
        public string Description { get; set; }

        public IEnumerable<ApplicationUser> Employees { get; set; }

        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        [Display(Name = "Date Completed")]
        public string CompleteDate { get; set; }

        public TaskStatus Status { get; set; }

        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        [Display(Name = "Total Time")]
        public int TotalTime { get; set; }

        public bool Block { get; set; }
        
        public string Notes { get; set; }

        [Display(Name = "Part Number")]
        public string partNum { get; set; }
    }
}
