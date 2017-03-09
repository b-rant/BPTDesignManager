// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="ApplicationUser.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoT_v6.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    /// <summary>
    /// Class ApplicationUser.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser" />
    public class ApplicationUser : IdentityUser
    {


        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the employee todo.
        /// </summary>
        /// <value>The employee todo.</value>
        [NotMapped]
        public ICollection<EmployeeTodo> EmployeeTodo { get; set; }
        /// <summary>
        /// Gets or sets the employee work task.
        /// </summary>
        /// <value>The employee work task.</value>
        public ICollection<EmployeeWorkTask> EmployeeWorkTask { get; set; }

    }
}
