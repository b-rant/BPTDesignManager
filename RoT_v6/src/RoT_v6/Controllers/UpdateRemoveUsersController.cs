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
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
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
            var currentUser = await GetCurrentUserAsync();
            model.users = await _userManager.Users.Where(m => m.Id != currentUser.Id).Include(item => item.Roles).ToListAsync();
            model.roles = await _roleManager.Roles.ToListAsync();

            return View(model);
        }

        //[ValidateAntiForgeryToken]
        //[HttpPost]
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
        [HttpGet("deleteUser/{userID}")]
        public async Task<ActionResult> deleteUser(string userID)
        {
            var user = await _userManager.FindByIdAsync(userID);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
    }
}