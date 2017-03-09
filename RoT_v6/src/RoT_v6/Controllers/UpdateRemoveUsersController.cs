// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="UpdateRemoveUsersController.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RoT_v6.Models;
using RoT_v6.Data;
using Microsoft.AspNetCore.Identity;
using RoT_v6.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data;

namespace RoT_v6.Controllers
{
    /// <summary>
    /// Class UpdateRemoveUsersController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize(Roles = "Admin")]
    public class UpdateRemoveUsersController : Controller
    {
        /// <summary>
        /// Gets the current user asynchronous.
        /// </summary>
        /// <returns>Task&lt;ApplicationUser&gt;.</returns>
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        /// <summary>
        /// The role manager
        /// </summary>
        private readonly RoleManager<IdentityRole> _roleManager;
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateRemoveUsersController"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="roleManager">The role manager.</param>
        /// <param name="context">The context.</param>
        public UpdateRemoveUsersController(UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager, ApplicationDbContext context) {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async  Task<IActionResult> Index()
        {
            UpdateUserRoleModel model = new UpdateUserRoleModel();
            var currentUser = await GetCurrentUserAsync();
            model.users = await _userManager.Users.Where(m => m.Id != currentUser.Id).Include(item => item.Roles).ToListAsync();
            model.roles = await _roleManager.Roles.ToListAsync();

            return View(model);
        }

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        /// <summary>
        /// Updates the role.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <param name="role">The role.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [HttpGet("updateRole/{userID}/{role}")]
        public async Task<ActionResult> updateRole(string userID, string role)
        {
            var roles = _context.Roles.ToList();
            var users = _context.Users.ToList();

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userID);
                var userId = user.Id;
                var oldRoleName = await _userManager.GetRolesAsync(user);

 
                    await _userManager.RemoveFromRoleAsync(user, oldRoleName[0]);
                    await _userManager.AddToRoleAsync(user, role);

                _context.Entry(user).State = EntityState.Modified;

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        //[HttpPost]
        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [HttpGet("deleteUser/{userID}")]
        public async Task<ActionResult> deleteUser(string userID)
        {
            var user = await _userManager.FindByIdAsync(userID);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
    }
}