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
        private readonly RoTContext _context;

        public WorkTasksController(RoTContext context)
        {
            _context = context;    
        }

        // GET: WorkTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkTasks.ToListAsync());
        }

        // GET: WorkTasks/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskID,Block,CompleteDate,Description,Employee,JobID,Notes,StartDate,StartTime,Status,TotalTime,partNum")] WorkTask workTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workTask);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(workTask);
        }

        // GET: WorkTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: WorkTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskID,Block,CompleteDate,Description,Employee,JobID,Notes,StartDate,StartTime,Status,TotalTime,partNum")] WorkTask workTask)
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
                return RedirectToAction("Index");
            }
            return View(workTask);
        }

        // GET: WorkTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: WorkTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workTask = await _context.WorkTasks.SingleOrDefaultAsync(m => m.TaskID == id);
            _context.WorkTasks.Remove(workTask);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WorkTaskExists(int id)
        {
            return _context.WorkTasks.Any(e => e.TaskID == id);
        }
    }
}
