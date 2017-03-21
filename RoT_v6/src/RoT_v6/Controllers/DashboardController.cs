using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoT_v6.ViewModels;
using RoT_v6.Models;
using RoT_v6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace RoT_v6.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private decimal HourRate = 75;

        public DashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await GetCurrentUserAsync();
            var roleList = await _userManager.GetRolesAsync(currentUser);
            //var CompletedTasks = await _context.WorkTasks.Where(m => m.Status.ToString() == "Completed" && m.employeeId == currentUser.name).ToListAsync();
            var ActiveTasks = await _context.WorkTasks.Where(m => m.Status.ToString() != "Completed" && m.employeeId == currentUser.name).ToListAsync();

            if (roleList.Contains("Employee"))
            {
                var user = await _userManager.Users.ToListAsync();
                var EmployeeTodo = await _context.ToDos.Include(m => m.EmployeeTodo).ToListAsync();
                List<ToDo> pick2List = new List<ToDo>();
                List<EmployeeTodo> bridge = await _context.EmployeeTodo.ToListAsync();
                List<int> toIDs = new List<int>();
                foreach (EmployeeTodo et in bridge)
                {
                    if (currentUser.Id == et.employee.Id)
                    {
                        toIDs.Add(et.ToDoId);
                    }
                }
                foreach (ToDo td in EmployeeTodo)
                {
                    if (toIDs.Contains(td.ToDoId))
                    {
                        pick2List.Add(td);
                    }
                }
                Dashboard_WorkTaskToDo WorkTaskToDo = new Dashboard_WorkTaskToDo()
                {
                    EmpToDo = pick2List,
                    ActiveTasks = ActiveTasks,
                    //CompletedTasks = CompletedTasks,
                    User = user
                };
                return View(WorkTaskToDo);
            }
            else
            {
                var user = await _userManager.Users.ToListAsync();
                var EmployeeTodo = await _context.ToDos.Include(m => m.EmployeeTodo).ToListAsync();
                Dashboard_WorkTaskToDo WorkTaskToDo = new Dashboard_WorkTaskToDo()
                {
                    EmpToDo = EmployeeTodo,
                    ActiveTasks = ActiveTasks,
                    //CompletedTasks = CompletedTasks,
                    User = user
                };
                return View(WorkTaskToDo);
            }
        }

        [Authorize]
        public async Task<IActionResult> AllTasks()
        {
            var allTasksActive = await _context.WorkTasks.Where(m => m.Status.ToString() != "Completed").ToListAsync();
            var allTasksCompleted = await _context.WorkTasks.Where(m => m.Status.ToString() == "Completed").ToListAsync();
            Dashboard_WorkTaskToDo WorkTaskToDo = new Dashboard_WorkTaskToDo();
            WorkTaskToDo.ActiveTasks = allTasksActive;
            WorkTaskToDo.CompletedTasks = allTasksCompleted;
            return View(WorkTaskToDo);
        }


        [Authorize]
        public async Task<IActionResult> Index_editTaskStatus(int? id, string Status)
        {
            if (id == null || Status == null)
            {
                return NotFound();
            }
            await changeStatus(id, Status);
            // Return view
            return RedirectToAction("Index", "Dashboard");
        }

        [Authorize]
        public async Task<IActionResult> All_editTaskStatus(int? id, string Status)
        {
            if (id == null || Status == null)
            {
                return NotFound();
            }
            await changeStatus(id, Status);
            // Return view
            return RedirectToAction("AllTasks", "Dashboard");
        }

        [Authorize]
        public async Task changeStatus(int? id, string Status)
        {

            // Get task
            var task = await _context.WorkTasks.SingleOrDefaultAsync(m => m.TaskID == id);
            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobID == task.JobID);
            DateTime date = DateTime.UtcNow;
            // Edit Status
            switch (Status)
            {
                case "Complete":
                    if (task.Status != Models.TaskStatus.InProgress)
                    {
                        break;
                    }
                    task.Status = Models.TaskStatus.Completed;
                    DateTime startTime = Convert.ToDateTime(task.StartTime);
                    task.TotalTime = task.TotalTime + date.Subtract(startTime).Minutes;
                    task.CompleteDate = date.ToString("d");
                    job.InvHours = job.InvHours + (int)task.TotalTime;
                    Decimal cost = (task.TotalTime * HourRate) / 60;
                    job.InvCost = job.InvCost + cost; //((task.TotalTime / 60) * HourRate);
                    break;
                case "CompleteFromPause":
                    task.Status = Models.TaskStatus.Completed;
                    task.CompleteDate = date.ToString("d");
                    job.InvHours = job.InvHours + (int)task.TotalTime;
                    Decimal cost2 = (task.TotalTime * HourRate) / 60;
                    job.InvCost = job.InvCost + cost2; //((task.TotalTime / 60) * HourRate);
                    break;
                case "Pause":
                    task.Status = Models.TaskStatus.Pause;
                    DateTime sTime = Convert.ToDateTime(task.StartTime);
                    task.TotalTime = task.TotalTime + date.Subtract(sTime).Minutes;
                    break;
                case "InProgress":
                    task.Status = Models.TaskStatus.InProgress;
                    task.StartTime = date.ToString();
                    break;
            }
            // Post to database
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
        }
    }
}