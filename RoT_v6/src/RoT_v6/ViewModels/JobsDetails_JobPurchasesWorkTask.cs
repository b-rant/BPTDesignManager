// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="JobsDetails_JobPurchasesWorkTask.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RoT_v6.Data;
using RoT_v6.Models;
using System.Collections.Generic;

namespace RoT_v6.ViewModels
{
    /// <summary>
    /// Class JobsDetails_JobPurchasesWorkTask.
    /// </summary>
    public class JobsDetails_JobPurchasesWorkTask
    {
        /// <summary>
        /// Gets or sets the job.
        /// </summary>
        /// <value>The job.</value>
        public Job Job { get; set; }
        /// <summary>
        /// Gets or sets the purchases.
        /// </summary>
        /// <value>The purchases.</value>
        public List<Purchase> Purchases { get; set; }
        /// <summary>
        /// Gets or sets the active tasks.
        /// </summary>
        /// <value>The active tasks.</value>
        public List<WorkTask> ActiveTasks { get; set; }
        /// <summary>
        /// Gets or sets the completed tasks.
        /// </summary>
        /// <value>The completed tasks.</value>
        public List<WorkTask> CompletedTasks { get; set; }
        /// <summary>
        /// Gets or sets the employee work task.
        /// </summary>
        /// <value>The employee work task.</value>
        public List<EmployeeWorkTask> EmployeeWorkTask { get; set; }
        /// <summary>
        /// Gets or sets the employee todo.
        /// </summary>
        /// <value>The employee todo.</value>
        public List<EmployeeTodo> EmployeeTodo { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public List<ApplicationUser> User { get; set; }




    }
}
