using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoT_v6.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RoT_v6.Data
{
    public class RoTContext : DbContext
    {
        public RoTContext(DbContextOptions<RoTContext> options) : base(options)
        {
        }     
        
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<ToDo> ToDos {get; set;}
        public DbSet<WorkTask> WorkTasks { get; set; }
    }
}
