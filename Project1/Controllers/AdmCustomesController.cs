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
    public class AdmCustomesController : Controller
    {
        private readonly MvcProject1Context _context;

        public AdmCustomesController(MvcProject1Context context)
        {
            _context = context;
        }

        // GET: AdmCustomes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdmCustomerViewModel.ToListAsync());
        }

        // GET: AdmCustomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admCustomerViewModel = await _context.AdmCustomerViewModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (admCustomerViewModel == null)
            {
                return NotFound();
            }

            return View(admCustomerViewModel);
        }

        // GET: AdmCustomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdmCustomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Firstname,Lastname,SearchString,CityLocation")] AdmCustomerViewModel admCustomerViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admCustomerViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admCustomerViewModel);
        }

        // GET: AdmCustomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admCustomerViewModel = await _context.AdmCustomerViewModel.FindAsync(id);
            if (admCustomerViewModel == null)
            {
                return NotFound();
            }
            return View(admCustomerViewModel);
        }

        // POST: AdmCustomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Firstname,Lastname,SearchString,CityLocation")] AdmCustomerViewModel admCustomerViewModel)
        {
            if (id != admCustomerViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admCustomerViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdmCustomerViewModelExists(admCustomerViewModel.ID))
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
            return View(admCustomerViewModel);
        }

        // GET: AdmCustomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admCustomerViewModel = await _context.AdmCustomerViewModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (admCustomerViewModel == null)
            {
                return NotFound();
            }

            return View(admCustomerViewModel);
        }

        // POST: AdmCustomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admCustomerViewModel = await _context.AdmCustomerViewModel.FindAsync(id);
            _context.AdmCustomerViewModel.Remove(admCustomerViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdmCustomerViewModelExists(int id)
        {
            return _context.AdmCustomerViewModel.Any(e => e.ID == id);
        }
    }
}
