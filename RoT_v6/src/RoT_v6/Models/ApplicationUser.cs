using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoT_v6.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

      
        public string name { get; set; }
        [NotMapped]
        public ICollection<EmployeeTodo> EmployeeTodo { get; set; }
     public ICollection<EmployeeWorkTask> EmployeeWorkTask { get; set; }

    }
}
