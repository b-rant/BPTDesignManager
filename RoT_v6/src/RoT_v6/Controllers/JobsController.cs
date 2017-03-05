using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoT_v6.Data;
using RoT_v6.Models;
using RoT_v6.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace RoT_v6.Controllers
{
    [Authorize]
    public class JobsController : Controller
    {
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jobs.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUser = await GetCurrentUserAsync();
            var roleList = await _userManager.GetRolesAsync(currentUser);

            if (roleList.Contains("Employee"))
            {

                var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobID == id);
                var Purchases = await _context.Purchase.Where(m => m.JobID == id).ToListAsync();
                var ActiveTasks = await _context.WorkTasks.Where(m => m.JobID == id && m.Status.ToString() != "Completed").ToListAsync();
                List<WorkTask> pickList = new List<WorkTask>();
                foreach (WorkTask w in ActiveTasks)
                {
                    if (w.employeeId == currentUser.name && !w.Block)
                    {
                        pickList.Add(w);
                    }

                }

                var CompletedTasks = await _context.WorkTasks.Where(m => m.JobID == id && m.Status.ToString() == "Completed").ToListAsync();
                JobsDetails_JobPurchasesWorkTask JobPurchasesWorkTasks = new JobsDetails_JobPurchasesWorkTask()
                {
                    Job = job,
                    Purchases = Purchases,
                    ActiveTasks = pickList,
                    CompletedTasks = CompletedTasks
                };
                if (job == null)
                {
                    return NotFound();
                }

                return View(JobPurchasesWorkTasks);
            }
            else
            {
                var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobID == id);
                var Purchases = await _context.Purchase.Where(m => m.JobID == id).ToListAsync();
                var ActiveTasks = await _context.WorkTasks.Where(m => m.JobID == id && m.Status.ToString() != "Completed").ToListAsync();
                List<WorkTask> pickList = new List<WorkTask>();
                foreach (WorkTask w in ActiveTasks)
                {
                    if (w.employeeId == currentUser.name && !w.Block)
                    {
                        pickList.Add(w);
                    }

                }

                var CompletedTasks = await _context.WorkTasks.Where(m => m.JobID == id && m.Status.ToString() == "Completed").ToListAsync();
                JobsDetails_JobPurchasesWorkTask JobPurchasesWorkTasks = new JobsDetails_JobPurchasesWorkTask()
                {
                    Job = job,
                    Purchases = Purchases,
                    ActiveTasks = pickList,
                    CompletedTasks = CompletedTasks
                };
                if (job == null)
                {
                    return NotFound();
                }

                return View(JobPurchasesWorkTasks);
            }
        }

        // GET: Jobs/Create
        [Authorize(Roles = "Admin, ShopManager")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, ShopManager")]
        public async Task<IActionResult> Create([Bind("JobID,Client,CompleteDate,Description,DesiredDate,EstCost,EstHours,InvCost,InvHours,StartDate,Status,jobNum")] Job job)
        {
            DateTime dateOnly = DateTime.Today;
            job.StartDate = dateOnly.ToString("d");
            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: Jobs/EditDetails/5
        [Authorize(Roles = "Admin, ShopManager")]
        public async Task<IActionResult> EditDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobID == id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // GET: Jobs/EditJobsList/5
        [Authorize(Roles = "Admin, ShopManager")]
        public async Task<IActionResult> EditJobsList(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobID == id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> EditDetails(int id, [Bind("JobID,Client,CompleteDate,Description,DesiredDate,EstCost,EstHours,InvCost,InvHours,StartDate,Status,jobNum")] Job job)
        {
            if (id != job.JobID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.JobID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Jobs", new { id = job.JobID }); ;
            }
            return View(job);
        }

        // POST: Jobs/EditJobsList/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> EditJobsList(int id, [Bind("JobID,Client,CompleteDate,Description,DesiredDate,EstCost,EstHours,InvCost,InvHours,StartDate,Status,jobNum")] Job job)
        {
            if (id != job.JobID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.JobID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        [Authorize(Roles = "Admin, ShopManager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobID == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, ShopManager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobID == id);
            var Purchases = await _context.Purchase.Where(m => m.JobID == id).ToListAsync();
            var Tasks = await _context.WorkTasks.Where(m => m.JobID == id).ToListAsync();
            foreach (WorkTask task in Tasks)
            {
                _context.WorkTasks.Remove(task);
            }
            foreach (Purchase purchase in Purchases)
            {
                _context.Purchase.Remove(purchase);
            }
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.JobID == id);
        }
    }
}
