// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="initialize.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// <summary>
    /// Class initialize.
    /// </summary>
    public class initialize
    {
        /// <summary>
        /// Creates the roles.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>Task.</returns>
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
              //var user = await userMan.FindByIdAsync("f577865d-4c37-4aaa-bd19-e828e18a54a8");
              //await userMan.AddToRoleAsync(user, "Admin");
          } 

    }
}
