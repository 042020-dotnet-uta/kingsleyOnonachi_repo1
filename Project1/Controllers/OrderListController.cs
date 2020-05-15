using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProject1.Data;
using MvcProject1.Models;

namespace MvcProject1.Controllers
{
    public class OrderListController : Controller
    {
        private readonly MvcProject1Context _context;

        public OrderListController(MvcProject1Context context)
        {
            _context = context;
        }

        // GET: OrderList
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderListViewModel.ToListAsync());
        }

        // GET: OrderList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderListViewModel = await _context.OrderListViewModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (orderListViewModel == null)
            {
                return NotFound();
            }

            return View(orderListViewModel);
        }

        // GET: OrderList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SearchString,CustomerID")] OrderListViewModel orderListViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderListViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderListViewModel);
        }

        // GET: OrderList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderListViewModel = await _context.OrderListViewModel.FindAsync(id);
            if (orderListViewModel == null)
            {
                return NotFound();
            }
            return View(orderListViewModel);
        }

        // POST: OrderList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SearchString,CustomerID")] OrderListViewModel orderListViewModel)
        {
            if (id != orderListViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderListViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderListViewModelExists(orderListViewModel.ID))
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
            return View(orderListViewModel);
        }

        // GET: OrderList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderListViewModel = await _context.OrderListViewModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (orderListViewModel == null)
            {
                return NotFound();
            }

            return View(orderListViewModel);
        }

        // POST: OrderList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderListViewModel = await _context.OrderListViewModel.FindAsync(id);
            _context.OrderListViewModel.Remove(orderListViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderListViewModelExists(int id)
        {
            return _context.OrderListViewModel.Any(e => e.ID == id);
        }
    }
}
