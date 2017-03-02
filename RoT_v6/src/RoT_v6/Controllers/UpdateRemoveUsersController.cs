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
    [Authorize(Roles = "Admin")]
    public class UpdateRemoveUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public UpdateRemoveUsersController(UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager, ApplicationDbContext context) {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async  Task<IActionResult> Index()
        {
            UpdateUserRoleModel model = new UpdateUserRoleModel();
            model.users = await _userManager.Users.Include(item => item.Roles).ToListAsync();
            model.roles = await _roleManager.Roles.ToListAsync();

            return View(model);
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        [Route("UpdateRemoveUsers/updateRole/{userID:maxLength(34)}/{role:maxLength(14)}", Name = "updateRole")]
        public async Task<ActionResult> updateRole(String userID, String role)
        {
            var roles = _context.Roles.ToList();
            var users = _context.Users.ToList();
            bool successfullyChanged = false;

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userID);
                var userId = user.Id;
                var oldRoleName = await _userManager.GetRolesAsync(user);

 
                    await _userManager.RemoveFromRoleAsync(user, oldRoleName[0]);
                    await _userManager.AddToRoleAsync(user, role);
                    successfullyChanged = true;

                _context.Entry(user).State = EntityState.Modified;

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}