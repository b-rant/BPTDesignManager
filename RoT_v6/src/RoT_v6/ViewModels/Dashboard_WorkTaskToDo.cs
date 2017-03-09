// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="Dashboard_WorkTaskToDo.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RoT_v6.Models;
using System.Collections.Generic;

namespace RoT_v6.ViewModels
{
    /// <summary>
    /// Class Dashboard_WorkTaskToDo.
    /// </summary>
    public class Dashboard_WorkTaskToDo
    {

        /// <summary>
        /// Gets or sets the completed tasks.
        /// </summary>
        /// <value>The completed tasks.</value>
        public List<WorkTask> CompletedTasks { get; set; }
        /// <summary>
        /// Gets or sets the active tasks.
        /// </summary>
        /// <value>The active tasks.</value>
        public List<WorkTask> ActiveTasks { get; set; }
        /// <summary>
        /// Gets or sets the emp to do.
        /// </summary>
        /// <value>The emp to do.</value>
        public List<ToDo> EmpToDo { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public List<ApplicationUser> User { get; set; }
    }
}
