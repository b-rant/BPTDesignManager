// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="EmployeeWorkTask.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RoT_v6.Models
{

    /// <summary>
    /// Class EmployeeWorkTask.
    /// </summary>
    public class EmployeeWorkTask
    {

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        [ForeignKey("employeeId")]
        public string employeeId { get; set; }
        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        public ApplicationUser employee { get; set; }

        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>The task identifier.</value>
        [ForeignKey("TaskId")]
        public int TaskId { get; set; }
        /// <summary>
        /// Gets or sets the work task item.
        /// </summary>
        /// <value>The work task item.</value>
        public WorkTask WorkTaskItem { get; set; }



    }



}
