using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProject1.BusinessLogic;
using MvcProject1.Data;
using MvcProject1.DataLogic;
using MvcProject1.Models;

namespace MvcProject1.Controllers
{
    public class AdmCustomersController : Controller
    {
        private readonly IProductRepository _productRepository;
        private ICustomerRepository _customerRepository;

        public AdmCustomersController(IProductRepository productRepository, ICustomerRepository customerRepository)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        // GET: AdmCustomes
        public async Task<IActionResult> Index()
        {
            var customers = _customerRepository.GetAllCustomers();


            foreach (var item in customers)
            {
                Console.WriteLine(item.CityAddress);
            }

            var AdmCustomersViewModel = new AdmCustomerViewModel
            {
                Customers = customers.ToList(),
            };
            return View(AdmCustomersViewModel);
        }

        // //GET: AdmCustomes/Details/5
        //public Task <IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customerView = _customerRepository.GetCustomerViewByID(id.Value);

        //    return View(customerView);
        //}

        // GET: AdmCustomes/Create
        public IActionResult Create()
        {
            return RedirectToAction("Registration", "Customer");
        }

        // POST: AdmCustomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID,Firstname,Lastname,SearchString,CityLocation")] CustomerViewModel admCustomerViewModel)
        {
            if (ModelState.IsValid)
            {


                return RedirectToAction(nameof(Index));

            }
            return View(admCustomerViewModel);
        }

        // GET: AdmCustomes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var admCustomerViewModel = await _pr;
        //    if (admCustomerViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(admCustomerViewModel);
        //}

        // POST: AdmCustomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("CustomerID,Firstname,Lastname,SearchString,CityLocation")] AdmCustomerViewModel admCustomerViewModel)
        //{
        //    if (id != admCustomerViewModel.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(admCustomerViewModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AdmCustomerViewModelExists(admCustomerViewModel.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(admCustomerViewModel);
        //}

        // GET: AdmCustomes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var admCustomerViewModel = await _context.Inventory
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (admCustomerViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(admCustomerViewModel);
        //}

        //// POST: AdmCustomes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var admCustomerViewModel = await _context.Inventory.FindAsync(id);
        //    _context.Inventory.Remove(admCustomerViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AdmCustomerViewModelExists(int id)
        //{
        //    return _context.Inventory.Any(e => e.ID == id);
        //}
    }
}
