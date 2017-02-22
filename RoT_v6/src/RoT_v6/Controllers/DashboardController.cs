using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoT_v6.ViewModels;
using RoT_v6.Models;
using RoT_v6.Data;
using Microsoft.EntityFrameworkCore;

namespace RoT_v6.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ToDos = await _context.ToDos.ToListAsync();
            var CompletedTasks = await _context.WorkTasks.Where(m => m.Status.ToString() == "Completed").ToListAsync();
            var ActiveTasks = await _context.WorkTasks.Where(m => m.Status.ToString() != "Completed").ToListAsync();
            Dashboard_WorkTaskToDo WorkTaskToDo = new Dashboard_WorkTaskToDo()
            {
                ToDos = ToDos,
                ActiveTasks = ActiveTasks,
                CompletedTasks = CompletedTasks
            };
            return View(WorkTaskToDo);
        }

        public async Task<IActionResult> editTaskStatus(int? id, string Status)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Get task
            var task = await _context.WorkTasks.SingleOrDefaultAsync(m => m.TaskID == id);
            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobID == task.JobID);
            if (task == null || job == null)
            {
                return NotFound();
            }
            DateTime date = DateTime.UtcNow;
            // Edit Status
            switch (Status)
            {
                case "Complete":
                    task.Status = Models.TaskStatus.Completed;
                    DateTime startTime = Convert.ToDateTime(task.StartTime);
                    task.TotalTime = task.TotalTime + date.Subtract(startTime).Minutes;
                    task.CompleteDate = date.ToString("d");
                    job.InvHours = job.InvHours + (int)task.TotalTime;
                    break;
                case "CompleteFromPause":
                    task.Status = Models.TaskStatus.Completed;
                    task.CompleteDate = date.ToString("d");
                    job.InvHours = job.InvHours + (int)task.TotalTime;
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
            // Return view
            return RedirectToAction("Index", "Dashboard");
        }
    }
}