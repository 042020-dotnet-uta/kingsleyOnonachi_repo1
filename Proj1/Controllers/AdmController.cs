using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proj1.BusinessLogic;
using Proj1.Data;
using Proj1.Models;

namespace Proj1.Controllers
{
    public class AdmController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public AdmController(ICustomerRepository customerRepository, object p)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        // GET: Customers
        
        public async Task<IActionResult> Index(int? SearchType, string searchString)
        {
            List<Customer> customers;
            if (!String.IsNullOrEmpty(searchString))
            {
                //Build a predicate to send to the repository to search
                var predicate = CreatePredicate(SearchType.GetValueOrDefault(), searchString);
                //customers = await _customerRepository.GetCustomerByID(SearchType.Value);

            }
            else
            {
                customers = _customerRepository.GetAllCustomers();
            }
            customers = _customerRepository.GetAllCustomers();
            var customersView = new AdmCustomerViewModel
            {
                Customers = customers
            };


            return View(customersView);

        }
        private Expression<Func<Customer, bool>> CreatePredicate(int SearchType, string searchString)
        {
            Expression<Func<Customer, bool>> newFunc;
            switch (SearchType)
            {
                case 0:
                    newFunc = (c => c.FirstName.Contains(searchString));
                    break;
                case 1:
                    newFunc = (c => c.LastName.Contains(searchString));
                    break;
                case 2:
                    newFunc = (c => c.Email.Contains(searchString));
                    break;
                default:
                    newFunc = null;
                    break;
            }
            return newFunc;
        }

        public IActionResult ResetSearch()
        {
            return RedirectToAction("Index");
        }

        // GET: Customers/Create
        [Authorize(Roles = "Admin")]
        public IActionResult CreateNew()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNew(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer != null)
                {
                    var cust = _customerRepository.AddCustomer(customer);

                    return RedirectToAction("Index", "Customer");
                }
            }
            return View(customer);
        }

    }
}