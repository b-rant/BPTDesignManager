// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="ApplicationDbContext.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoT_v6.Models;

namespace RoT_v6.Data
{
    /// <summary>
    /// Class ApplicationDbContext.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{RoT_v6.Models.ApplicationUser}" />
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Configures the schema needed for the identity framework.
        /// </summary>
        /// <param name="builder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EmployeeTodo>().HasKey(k => new { k.employeeId, k.ToDoId });

        builder.Entity<EmployeeTodo>()
        .HasOne(pc => pc.employee)
        .WithMany(p => p.EmployeeTodo)
        .HasForeignKey(pc => pc.employeeId);

         builder.Entity<EmployeeTodo>()
        .HasOne(pc => pc.todoItem)
        .WithMany(p => p.EmployeeTodo)
        .HasForeignKey(pc => pc.ToDoId);

        builder.Entity<EmployeeWorkTask>().HasKey(k => new { k.employeeId, k.TaskId });

        builder.Entity<EmployeeWorkTask>()
        .HasOne(pc => pc.employee)
        .WithMany(p => p.EmployeeWorkTask)
            .HasForeignKey(pc => pc.employeeId);

            builder.Entity<EmployeeWorkTask>()
           .HasOne(pc => pc.WorkTaskItem)
           .WithMany(p => p.EmployeeWorkTask)
           .HasForeignKey(pc => pc.TaskId);




        }
        /// <summary>
        /// Gets or sets the identity role.
        /// </summary>
        /// <value>The identity role.</value>
        public DbSet<IdentityRole> identityRole { get; set; }
        /// <summary>
        /// Gets or sets the jobs.
        /// </summary>
        /// <value>The jobs.</value>
        public DbSet<Job> Jobs { get; set; }
        /// <summary>
        /// Gets or sets the purchase.
        /// </summary>
        /// <value>The purchase.</value>
        public DbSet<Purchase> Purchase { get; set; }
        /// <summary>
        /// Gets or sets to dos.
        /// </summary>
        /// <value>To dos.</value>
        public DbSet<ToDo> ToDos { get; set; }
        /// <summary>
        /// Gets or sets the work tasks.
        /// </summary>
        /// <value>The work tasks.</value>
        public DbSet<WorkTask> WorkTasks { get; set; }
        /// <summary>
        /// Gets or sets the employee todo.
        /// </summary>
        /// <value>The employee todo.</value>
        public DbSet<EmployeeTodo> EmployeeTodo { get; set; }
        /// <summary>
        /// Gets or sets the employee task.
        /// </summary>
        /// <value>The employee task.</value>
        public DbSet<EmployeeWorkTask> EmployeeTask { get; set; }

    }

}
