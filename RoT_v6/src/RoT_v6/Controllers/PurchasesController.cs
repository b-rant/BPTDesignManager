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
    public class PurchasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchasesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Purchases
        public async Task<IActionResult> Index()
        {
            return View(await _context.Purchase.ToListAsync());
        }

        // GET: Purchases/DetailsPurchases/5
        public async Task<IActionResult> DetailsPurchases(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase.SingleOrDefaultAsync(m => m.purchID == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // GET: Purchases/DetailsDetails/5
        public async Task<IActionResult> DetailsJobDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase.SingleOrDefaultAsync(m => m.purchID == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // GET: Purchases/Create
        public IActionResult Create(int JobID)
        {
            Purchase purchase = new Purchase();
            purchase.JobID = JobID;
            return View(purchase);
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("purchID,ArrivedDate,Block,CostPer,Description,EstArrDate,IdealDelDate,JobID,PurchDate,Quantity,RequestDate,TotalCost,Vendor")] Purchase purchase)
        {
            DateTime dateOnly = DateTime.Today;
            purchase.RequestDate = dateOnly.ToString("d");
            if (ModelState.IsValid)
            {
                _context.Add(purchase);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Jobs", new { id = purchase.JobID });
            }
            return View(purchase);
        }

        // GET: Purchases/EditJobDetails/5
        public async Task<IActionResult> EditJobDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase.SingleOrDefaultAsync(m => m.purchID == id);
            if (purchase == null)
            {
                return NotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/EditJobDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditJobDetails(int id, [Bind("purchID,ArrivedDate,Block,CostPer,Description,EstArrDate,IdealDelDate,JobID,PurchDate,Quantity,RequestDate,TotalCost,Vendor")] Purchase purchase)
        {
            if (id != purchase.purchID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseExists(purchase.purchID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Jobs", new { id = purchase.JobID });
            }
            return View(purchase);
        }

        // GET: Purchases/EditPurchases/5
        public async Task<IActionResult> EditPurchases(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase.SingleOrDefaultAsync(m => m.purchID == id);
            if (purchase == null)
            {
                return NotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/EditPurchases/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPurchases(int id, [Bind("purchID,ArrivedDate,Block,CostPer,Description,EstArrDate,IdealDelDate,JobID,PurchDate,Quantity,RequestDate,TotalCost,Vendor")] Purchase purchase)
        {
            if (id != purchase.purchID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseExists(purchase.purchID))
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
            return View(purchase);
        }

        // GET: Purchases/DeleteJobDetails/5
        public async Task<IActionResult> DeleteJobDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase.SingleOrDefaultAsync(m => m.purchID == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/DeleteJobDetails/5
        [HttpPost, ActionName("DeleteJobDetails")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteJobDetailsConfirmed(int id)
        {
            var purchase = await _context.Purchase.SingleOrDefaultAsync(m => m.purchID == id);
            _context.Purchase.Remove(purchase);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Jobs", new { id = purchase.JobID });
        }

        // GET: Purchases/DeletePurchases/5
        public async Task<IActionResult> DeletePurchases(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase.SingleOrDefaultAsync(m => m.purchID == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/DeletePurchases/5
        [HttpPost, ActionName("DeletePurchases")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePurchasesConfirmed(int id)
        {
            var purchase = await _context.Purchase.SingleOrDefaultAsync(m => m.purchID == id);
            _context.Purchase.Remove(purchase);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchase.Any(e => e.purchID == id);
        }
    }
}
