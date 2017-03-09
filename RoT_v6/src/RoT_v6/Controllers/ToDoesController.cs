// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="ToDoesController.cs" company="">
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
using Microsoft.AspNetCore.Authorization;

namespace RoT_v6.Controllers
{
    /// <summary>
    /// Class ToDoesController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    public class ToDoesController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;



        /// <summary>
        /// Initializes a new instance of the <see cref="ToDoesController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ToDoesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ToDoes
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToDos.ToListAsync());
        }

        // GET: ToDoes/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos.SingleOrDefaultAsync(m => m.ToDoId == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // GET: ToDoes/Create
        /// <summary>
        /// Creates the specified return URL.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>IActionResult.</returns>
        [Authorize]
        public  IActionResult Create(string returnUrl = null)
        {
            ToDo A = new ToDo();
            A.getEmployees(_context);
            
            ViewData["ReturnUrl"] = returnUrl;
            return View(A);
        }

        // POST: ToDoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the specified test.
        /// </summary>
        /// <param name="test">The test.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(ToDo test) {

            DateTime dateOnly = DateTime.Today;
            test.CreatedDate = dateOnly.ToString("d");
            if (ModelState.IsValid)
            {
                _context.Add(test);
                await _context.SaveChangesAsync();
                foreach (string e in test.employee)
                {
                    var todent = new EmployeeTodo { employeeId = e.ToString(), ToDoId = test.ToDoId };
                    _context.Add(todent);
                    await _context.SaveChangesAsync();
                }
               

                return RedirectToAction("Index","Dashboard");
            }
            ViewBag.Fail = "1";
            test.getEmployees(_context);
            return View(test);
        }

        // GET: ToDoes/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos.SingleOrDefaultAsync(m => m.ToDoId == id);
            toDo.getEmployees(_context);
            if (toDo == null)
            {
                return NotFound();
            }
            return View(toDo);
        }

        // POST: ToDoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="toDo">To do.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, ToDo toDo)
        {
            if (id != toDo.ToDoId)
            {
                return NotFound();
            }


            var empList = await _context.EmployeeTodo.ToListAsync();

            foreach (EmployeeTodo e in empList)
            {
                 if(e.ToDoId == toDo.ToDoId) { _context.EmployeeTodo.Remove(e); }
              
                await _context.SaveChangesAsync();
            }
            if (toDo.employee.Count() == 0)
            {
                ViewBag.Fail = "1";
                toDo.getEmployees(_context);
                return View(toDo);
            }
            foreach (string e in toDo.employee)
            {
                var todent = new EmployeeTodo { employeeId = e.ToString(), ToDoId = toDo.ToDoId };
                _context.Add(todent);
                await _context.SaveChangesAsync();
            }



            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(toDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(toDo.ToDoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index","Dashboard");
            }
            ViewBag.Fail = "1";
            toDo.getEmployees(_context);
            return View(toDo);
        }

        // GET: ToDoes/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos.SingleOrDefaultAsync(m => m.ToDoId == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // POST: ToDoes/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDo = await _context.ToDos.SingleOrDefaultAsync(m => m.ToDoId == id);
            _context.ToDos.Remove(toDo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Dashboard");
        }

        /// <summary>
        /// To the do exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [Authorize]
        private bool ToDoExists(int id)
        {
            return _context.ToDos.Any(e => e.ToDoId == id);
        }
    }
}
