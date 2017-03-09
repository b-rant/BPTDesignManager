// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="ToDo.cs" company="">
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
    /// Enum priorityStatus
    /// </summary>
    public enum priorityStatus
    {
        /// <summary>
        /// The high
        /// </summary>
        High,
        /// <summary>
        /// The medium
        /// </summary>
        Medium,
        /// <summary>
        /// The low
        /// </summary>
        Low
    }

    /// <summary>
    /// Class ToDo.
    /// </summary>
    public class ToDo
    {
        /// <summary>
        /// Gets or sets to do identifier.
        /// </summary>
        /// <value>To do identifier.</value>
        [Key]
        public int ToDoId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        [Display(Name = "Created Date")]     
        public string CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the due date.
        /// </summary>
        /// <value>The due date.</value>
        [Required]
        [Display(Name = "Due Date")]
        public string DueDate { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>The priority.</value>
        [Display(Name = "Priority")]
        public priorityStatus Priority { get; set; }


        /// <summary>
        /// Gets or sets the employed.
        /// </summary>
        /// <value>The employed.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Employee")]
        [UIHint("List")]
        [NotMapped]
        public List<SelectListItem> Employed { get; set; }
        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        [NotMapped]
        public List<string>employee{ get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToDo"/> class.
        /// </summary>
        public ToDo()
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
                    Value = Data.Id,
                    Text = Data.name
                });
            }
        }
        /// <summary>
        /// Gets or sets the employee todo.
        /// </summary>
        /// <value>The employee todo.</value>
        [NotMapped]
        public ICollection<EmployeeTodo> EmployeeTodo { get; set; }
















    }
}
