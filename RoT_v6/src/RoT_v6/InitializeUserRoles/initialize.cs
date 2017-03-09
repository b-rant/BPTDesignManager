using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RoT_v6.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RoT_v6.InitializeUserRoles
{
    public class initialize
    {
        public async Task CreateRoles(IServiceProvider serviceProvider)
          {
              var roleMan = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
              var userMan = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
              string[] rolesNames = { "Admin", "ShopManager", "Purchaser", "Employee" };
              IdentityResult result;
              foreach (var rolesName in rolesNames)
              {
                  var roleExist = await roleMan.RoleExistsAsync(rolesName);
                  if (!roleExist)
                  {
                      result = await roleMan.CreateAsync(new IdentityRole(rolesName));
                  }
              }
             
          } 

    }
}
