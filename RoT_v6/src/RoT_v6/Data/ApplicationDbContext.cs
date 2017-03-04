using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoT_v6.Models;

namespace RoT_v6.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

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
        public DbSet<IdentityRole> identityRole { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<WorkTask> WorkTasks { get; set; }
        public DbSet<EmployeeTodo> EmployeeTodo { get; set; }
        public DbSet<EmployeeWorkTask> EmployeeTask { get; set; }

    }

}
