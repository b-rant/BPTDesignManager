// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="EmployeeTodo.cs" company="">
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
    /// Class EmployeeTodo.
    /// </summary>
    public class EmployeeTodo
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
        /// Gets or sets to do identifier.
        /// </summary>
        /// <value>To do identifier.</value>
        [ForeignKey("ToDoId")]
        public int ToDoId { get; set; }
        /// <summary>
        /// Gets or sets the todo item.
        /// </summary>
        /// <value>The todo item.</value>
        public ToDo todoItem { get; set; }





    }



}
