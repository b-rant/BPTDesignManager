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
    [Authorize]
    public class ToDoesController : Controller
    {
        private readonly ApplicationDbContext _context;


       
        public ToDoesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ToDoes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToDos.ToListAsync());
        }

        // GET: ToDoes/Details/5
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(ToDo test) {          
             

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
            return View(test);
        }

        // GET: ToDoes/Edit/5
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
            return View(toDo);
        }

        // GET: ToDoes/Delete/5
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

        [Authorize]
        private bool ToDoExists(int id)
        {
            return _context.ToDos.Any(e => e.ToDoId == id);
        }
    }
}
