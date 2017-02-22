using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoT_v6.Data;
using RoT_v6.Models;

namespace RoT_v6.Controllers
{
    public class WorkTasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkTasksController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: WorkTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkTasks.ToListAsync());
        }

        // GET: WorkTasks/DetailsDashboard/5
        public async Task<IActionResult> DetailsDashboard(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workTask = await _context.WorkTasks.SingleOrDefaultAsync(m => m.TaskID == id);
            if (workTask == null)
            {
                return NotFound();
            }

            return View(workTask);
        }

        // GET: WorkTasks/DetailsJobDetails/5
        public async Task<IActionResult> DetailsJobDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workTask = await _context.WorkTasks.SingleOrDefaultAsync(m => m.TaskID == id);
            if (workTask == null)
            {
                return NotFound();
            }

            return View(workTask);
        }

        // GET: WorkTasks/Create
        public IActionResult Create(int JobID)
        {
            WorkTask worktask = new WorkTask();
            worktask.JobID = JobID;
            return View(worktask);
        }

        // POST: WorkTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int JobID, [Bind("TaskID,Block,CompleteDate,Description,Employee,JobID,Notes,StartDate,StartTime,Status,TotalTime,partNum")] WorkTask workTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workTask);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details","Jobs",new { id = JobID});
            }
            return View(workTask);
        }

        // GET: WorkTasks/EditDashboard/5
        public async Task<IActionResult> EditDashboard(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workTask = await _context.WorkTasks.SingleOrDefaultAsync(m => m.TaskID == id);
            if (workTask == null)
            {
                return NotFound();
            }
            return View(workTask);
        }

        // POST: WorkTasks/EditDashboard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDashboard(int id, [Bind("TaskID,Block,CompleteDate,Description,Employee,JobID,Notes,StartDate,StartTime,Status,TotalTime,partNum")] WorkTask workTask)
        {
            if (id != workTask.TaskID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkTaskExists(workTask.TaskID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Dashboard");
            }
            return View(workTask);
        }

        // GET: WorkTasks/EditJobDetails/5
        public async Task<IActionResult> EditJobDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workTask = await _context.WorkTasks.SingleOrDefaultAsync(m => m.TaskID == id);
            if (workTask == null)
            {
                return NotFound();
            }
            return View(workTask);
        }

        // POST: WorkTasks/EditJobDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditJobDetails(int id, [Bind("TaskID,Block,CompleteDate,Description,Employee,JobID,Notes,StartDate,StartTime,Status,TotalTime,partNum")] WorkTask workTask)
        {
            if (id != workTask.TaskID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkTaskExists(workTask.TaskID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Jobs", new { id = workTask.JobID });
            }
            return View(workTask);
        }

        // GET: WorkTasks/DeleteDashboard/5
        public async Task<IActionResult> DeleteDashboard(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workTask = await _context.WorkTasks.SingleOrDefaultAsync(m => m.TaskID == id);
            if (workTask == null)
            {
                return NotFound();
            }

            return View(workTask);
        }

        // POST: WorkTasks/DeleteDashboard/5
        [HttpPost, ActionName("DeleteDashboard")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDashboardConfirmed(int id)
        {
            var workTask = await _context.WorkTasks.SingleOrDefaultAsync(m => m.TaskID == id);
            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobID == workTask.JobID);
            // Update Total Hours in job
            if (job != null)
            {
                job.InvHours = job.InvHours - (int)workTask.TotalTime;
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(job);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                }
            }
            _context.WorkTasks.Remove(workTask);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Dashboard");
        }

        // GET: WorkTasks/DeleteJobDetails/5
        public async Task<IActionResult> DeleteJobDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workTask = await _context.WorkTasks.SingleOrDefaultAsync(m => m.TaskID == id);
            if (workTask == null)
            {
                return NotFound();
            }

            return View(workTask);
        }

        // POST: WorkTasks/DeleteJobDetails/5
        [HttpPost, ActionName("DeleteJobDetails")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteJobDetailsConfirmed(int id)
        {
            var workTask = await _context.WorkTasks.SingleOrDefaultAsync(m => m.TaskID == id);
            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobID == workTask.JobID);
            // Update Total Hours in job
            if (job != null)
            {
                job.InvHours = job.InvHours - (int)workTask.TotalTime;
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(job);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                }
            }
            _context.WorkTasks.Remove(workTask);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Jobs", new { id = workTask.JobID });
        }

        private bool WorkTaskExists(int id)
        {
            return _context.WorkTasks.Any(e => e.TaskID == id);
        }
    }
}
