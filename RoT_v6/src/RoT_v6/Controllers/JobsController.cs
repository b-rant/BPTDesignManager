// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="JobsController.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// <summary>
    /// Class JobsController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    public class JobsController : Controller
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
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobsController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        public JobsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Jobs
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jobs.ToListAsync());
        }

        // GET: Jobs/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUser = await GetCurrentUserAsync();
            var roleList = await _userManager.GetRolesAsync(currentUser);

            //if (roleList.Contains("Employee"))
            //{

            //    var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobID == id);
            //    var Purchases = await _context.Purchase.Where(m => m.JobID == id).ToListAsync();
            //    var ActiveTasks = await _context.WorkTasks.Where(m => m.JobID == id && m.Status.ToString() != "Completed").ToListAsync();
            //    List<WorkTask> pickList = new List<WorkTask>();
            //    foreach (WorkTask w in ActiveTasks)
            //    {
            //        if (w.employeeId == currentUser.name && !w.Block)
            //        {
            //            pickList.Add(w);
            //        }

            //    }

            //    var CompletedTasks = await _context.WorkTasks.Where(m => m.JobID == id && m.Status.ToString() == "Completed").ToListAsync();
            //    JobsDetails_JobPurchasesWorkTask JobPurchasesWorkTasks = new JobsDetails_JobPurchasesWorkTask()
            //    {
            //        Job = job,
            //        Purchases = Purchases,
            //        ActiveTasks = pickList,
            //        CompletedTasks = CompletedTasks
            //    };
            //    if (job == null)
            //    {
            //        return NotFound();
            //    }

            //    return View(JobPurchasesWorkTasks);
            //}
            //else
            //{
            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobID == id);
            var Purchases = await _context.Purchase.Where(m => m.JobID == id).ToListAsync();
            var ActiveTasks = await _context.WorkTasks.Where(m => m.JobID == id && m.Status.ToString() != "Completed").ToListAsync();
            //List<WorkTask> pickList = new List<WorkTask>();
            //foreach (WorkTask w in ActiveTasks)
            //{
            //    if (w.employeeId == currentUser.name && !w.Block)
            //    {
            //        pickList.Add(w);
            //    }

            //}

            var CompletedTasks = await _context.WorkTasks.Where(m => m.JobID == id && m.Status.ToString() == "Completed").ToListAsync();
            JobsDetails_JobPurchasesWorkTask JobPurchasesWorkTasks = new JobsDetails_JobPurchasesWorkTask()
            {
                Job = job,
                Purchases = Purchases,
                //ActiveTasks = pickList,
                ActiveTasks = ActiveTasks,
                CompletedTasks = CompletedTasks
            };
            if (job == null)
            {
                return NotFound();
            }

            return View(JobPurchasesWorkTasks);
            //}
        }

        // GET: Jobs/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [Authorize(Roles = "Admin, ShopManager")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the specified job.
        /// </summary>
        /// <param name="job">The job.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
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

            ViewBag.Fail = "1";
            return View(job);
        }

        // GET: Jobs/EditDetails/5
        /// <summary>
        /// Edits the details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
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
        /// <summary>
        /// Edits the jobs list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
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
        /// <summary>
        /// Edits the details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="job">The job.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
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

            ViewBag.Fail = "1";
            return View(job);
        }

        // POST: Jobs/EditJobsList/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the jobs list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="job">The job.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
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
            ViewBag.Fail = "1";
            return View(job);
        }

        // GET: Jobs/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
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
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
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

        /// <summary>
        /// Jobs the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.JobID == id);
        }
    }
}
