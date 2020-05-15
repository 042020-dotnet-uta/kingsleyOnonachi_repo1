using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProject1.BusinessLogic;
using MvcProject1.Data;
using MvcProject1.Models;

namespace MvcProject1.Controllers
{
    public class InventoryController : Controller
    {
        private readonly MvcProject1Context _context;
        private IProductRepository _productRepository;

        public InventoryController(MvcProject1Context context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        // GET: Inventory
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventoryViewModel.ToListAsync());
        }

        // GET: Inventory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var inventoryViewModel = new InventoryViewModel();
            if (id != null)
            {
                inventoryViewModel = _productRepository.GetProductById(id);
            }
            else
            {
                return NotFound();
            }

            
               
            if (inventoryViewModel == null)
            {
                return NotFound();
            }

            return View(inventoryViewModel);
        }

        // GET: Inventory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,SearchString")] InventoryViewModel inventoryViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventoryViewModel);
        }

        // GET: Inventory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryViewModel = await _context.InventoryViewModel.FindAsync(id);
            if (inventoryViewModel == null)
            {
                return NotFound();
            }
            return View(inventoryViewModel);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,SearchString")] InventoryViewModel inventoryViewModel)
        {
            if (id != inventoryViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryViewModelExists(inventoryViewModel.ID))
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
            return View(inventoryViewModel);
        }

        // GET: Inventory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryViewModel = await _context.InventoryViewModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (inventoryViewModel == null)
            {
                return NotFound();
            }

            return View(inventoryViewModel);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryViewModel = await _context.InventoryViewModel.FindAsync(id);
            _context.InventoryViewModel.Remove(inventoryViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryViewModelExists(int id)
        {
            return _context.InventoryViewModel.Any(e => e.ID == id);
        }
    }
}
