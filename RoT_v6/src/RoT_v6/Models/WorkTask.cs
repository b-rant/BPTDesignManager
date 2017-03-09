// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="WorkTask.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// <summary>
    /// Enum TaskStatus
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// The created
        /// </summary>
        Created,
        /// <summary>
        /// The pause
        /// </summary>
        Pause,
        /// <summary>
        /// The in progress
        /// </summary>
        [Display(Name = "In Progress")]
        InProgress,
        /// <summary>
        /// The completed
        /// </summary>
        Completed
    }

    /// <summary>
    /// Class WorkTask.
    /// </summary>
    public class WorkTask
    {
        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>The task identifier.</value>
        [Key]
        public int TaskID { get; set; }

        /// <summary>
        /// Gets or sets the job identifier.
        /// </summary>
        /// <value>The job identifier.</value>
        public int JobID { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets the complete date.
        /// </summary>
        /// <value>The complete date.</value>
        [Display(Name = "Date Completed")]
        public string CompleteDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public TaskStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or sets the total time.
        /// </summary>
        /// <value>The total time.</value>
        [Display(Name = "Total Time")]
        public int TotalTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WorkTask"/> is block.
        /// </summary>
        /// <value><c>true</c> if block; otherwise, <c>false</c>.</value>
        public bool Block { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the part number.
        /// </summary>
        /// <value>The part number.</value>
        [Display(Name = "Part Number")]
        public string partNum { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        [Display(Name = "Employee")]
        public string employeeId { get; set; }

        /// <summary>
        /// Gets or sets the employee work task.
        /// </summary>
        /// <value>The employee work task.</value>
        [NotMapped]
        [Display(Name = "Employee's")]
        public ICollection<EmployeeWorkTask> EmployeeWorkTask { get; set; }

        /// <summary>
        /// Gets or sets the employed.
        /// </summary>
        /// <value>The employed.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Employee")]
        [UIHint("List")]
        [NotMapped]
        public List<SelectListItem> Employed { get; set; }

        //[NotMapped]
        //public List<string> employee { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkTask"/> class.
        /// </summary>
        public WorkTask()
        {
            Employed = new List<SelectListItem>();
        }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <param name="_context">The context.</param>
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
