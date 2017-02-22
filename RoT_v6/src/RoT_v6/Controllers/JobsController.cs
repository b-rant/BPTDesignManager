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


namespace RoT_v6.Controllers
{
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context)
        {
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

            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobID == id);
            var Purchases = await _context.Purchase.Where(m => m.JobID == id).ToListAsync();
            var WorkTasks = await _context.WorkTasks.Where(m => m.JobID == id).ToListAsync();
            JobsDetails_JobPurchasesWorkTask JobPurchasesWorkTasks = new JobsDetails_JobPurchasesWorkTask()
            {
                Job = job,
                Purchases = Purchases,
                WorkTasks = WorkTasks
            };
            if (job == null)
            {
                return NotFound();
            }

            return View(JobPurchasesWorkTasks);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobID == id);
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
