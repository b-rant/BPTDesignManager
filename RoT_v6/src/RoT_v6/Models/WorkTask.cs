using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoT_v6.Data;

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
        public string employeeId { get; set; }

        [NotMapped]
        [Display(Name = "Employee's")]
        public ICollection<EmployeeWorkTask> EmployeeWorkTask { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Employee")]
        [UIHint("List")]
        [NotMapped]
        public List<SelectListItem> Employed { get; set; }

        //[NotMapped]
        //public List<string> employee { get; set; }

        public WorkTask()
        {
            Employed = new List<SelectListItem>();
        }

        public void getEmployees(ApplicationDbContext _context)
        {
            var emp = from r in _context.Users select r;
            var listEmp = emp.ToList();
            foreach (var Data in listEmp)
            {
                Employed.Add(new SelectListItem()
                {
                    Value = Data.name,
                    Text = Data.name
                });
            }
        }



    }
}
