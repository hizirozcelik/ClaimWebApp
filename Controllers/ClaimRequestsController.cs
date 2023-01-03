using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClaimWebApp.Data;
using ClaimWebApp.Models;

namespace ClaimWebApp.Controllers
{
    public class ClaimRequestsController : Controller
    {
        private readonly AppDbContext _context;

        public ClaimRequestsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ClaimRequests
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClaimRequests.OrderByDescending(x => x.Id).ToListAsync());
        }

        // GET: ClaimRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClaimRequests == null)
            {
                return NotFound();
            }

            var claimRequest = await _context.ClaimRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (claimRequest == null)
            {
                return NotFound();
            }

            return View(claimRequest);
        }

        // GET: ClaimRequests/Create
        public IActionResult Create()
        {
            ClaimRequest claimRequest = new ClaimRequest();
            return View(claimRequest);
        }

        // POST: ClaimRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClaimRequest claimRequest)
        {
            if (claimRequest != null)
            {
                if (claimRequest.ClaimType == "Mileage")
                {
                    if (!claimRequest.IsOtherExpense)
                    {
                        OtherExpenseClaim otherExpense = new OtherExpenseClaim();
                        claimRequest.OtherExpenseClaims[0] = otherExpense;
                    }
                    ExpenseClaim expense = new ExpenseClaim();
                    claimRequest.ExpenseClaims[0] = expense;
                }
                else
                {
                    MileageClaim mileage = new MileageClaim();
                    claimRequest.MileageClaims[0] = mileage;
                    OtherExpenseClaim otherExpense = new OtherExpenseClaim();
                    claimRequest.OtherExpenseClaims[0] = otherExpense;
                }
                claimRequest.Status = "SAVED";
                _context.Add(claimRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(claimRequest);
        }

        // GET: ClaimRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClaimRequests == null)
            {
                return NotFound();
            }

            var claimRequest = await _context.ClaimRequests.FindAsync(id);
            if (claimRequest == null)
            {
                return NotFound();
            }

            // Adding claim details from other tables to the model
            if(claimRequest.ClaimType == "Mileage")
            {
                var mileages = _context.MileageClaims.Where(x => x.ClaimRequestId == id);
                claimRequest.MileageClaims = mileages.ToList();

                if(claimRequest.IsOtherExpense) 
                { 
                    var otherExpenses = _context.OtherExpenseClaims.Where(x => x.ClaimRequestId == id);
                    claimRequest.OtherExpenseClaims = otherExpenses.ToList();
                }
            } 
            else
            {
                var expenses = _context.ExpenseClaims.Where(x => x.ClaimRequestId == id);
                claimRequest.ExpenseClaims = expenses.ToList();
            }
            return View(claimRequest);
        }

        // POST: ClaimRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClaimRequest claimRequest)
        {
            if (id != claimRequest.Id)
            {
                return NotFound();
            }

            if (claimRequest != null)
            {
                if (claimRequest.ClaimType == "Mileage")
                {
                    if (!claimRequest.IsOtherExpense)
                    {

                        OtherExpenseClaim otherExpense = new OtherExpenseClaim();
                        claimRequest.OtherExpenseClaims[0] = otherExpense;
                    }
                    ExpenseClaim expense = new ExpenseClaim();
                    claimRequest.ExpenseClaims[0] = expense;
                }
                else
                {
                    MileageClaim mileage = new MileageClaim();
                    claimRequest.MileageClaims[0] = mileage;
                    OtherExpenseClaim otherExpense = new OtherExpenseClaim();
                    claimRequest.OtherExpenseClaims[0] = otherExpense;
                }

                try
                {
                    _context.Update(claimRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimRequestExists(claimRequest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(claimRequest);
        }

        // GET: ClaimRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClaimRequests == null)
            {
                return NotFound();
            }

            var claimRequest = await _context.ClaimRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (claimRequest == null)
            {
                return NotFound();
            }

            return View(claimRequest);
        }

        // POST: ClaimRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClaimRequests == null)
            {
                return Problem("Entity set 'AppDbContext.ClaimRequests'  is null.");
            }
            var claimRequest = await _context.ClaimRequests.FindAsync(id);
            var mileage = _context.MileageClaims.Where(e => e.ClaimRequestId == id).ToListAsync();
            foreach (var item in await mileage)
            {
                _context.MileageClaims.Remove(item);

            }

            var otherExpense = _context.OtherExpenseClaims.Where(e => e.ClaimRequestId == id).ToListAsync();
            foreach (var item in await otherExpense)
            {
                _context.OtherExpenseClaims.Remove(item);
 
            }
            var expense = _context.ExpenseClaims.Where(e => e.ClaimRequestId == id).ToListAsync();
            foreach (var item in await expense)
            {
                _context.ExpenseClaims.Remove(item);

            }
            await _context.SaveChangesAsync();
            _context.ClaimRequests.Remove(claimRequest);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ClaimRequestExists(int id)
        {
            return _context.ClaimRequests.Any(e => e.Id == id);
        }
    }
}
