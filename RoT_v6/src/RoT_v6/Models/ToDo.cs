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
    public enum priorityStatus
    {
        High,
        Medium,
        Low
    }

    public class ToDo
    {
        [Key]
        public int ToDoId { get; set; }

        [Display(Name = "Description")]

        [Required]
        public string Description { get; set; }

        [Display(Name = "Created Date")]     
        public string CreatedDate { get; set; }

        [Required]
        [Display(Name = "Due Date")]
        public string DueDate { get; set; }

        [Display(Name = "Priority")]
        public priorityStatus Priority { get; set; }
    }
}
