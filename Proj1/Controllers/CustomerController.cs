using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proj1.BusinessLogic;
using Proj1.Data;
using Proj1.Helpers;
using Proj1.Models;

namespace Proj1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public CustomerController(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
    }

        // GET: Customer
        public async Task<IActionResult> Index(object p, object p1)
        {
            var customers = _customerRepository.GetAllCustomers();
            
            var customerViewModel = new CustomerViewModel()
            {
               
            };
            if (customerViewModel == null)
                return View();
            return View(customers);
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = await _customerRepository.GetCustomerByID(id.Value);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID,FirstName,LastName,StreetAddress,CityAddress,StateAddress,CountryAddress,UserName,Email,PassWord,RegDate")] Customer customerViewModel)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.AddCustomer(customerViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(customerViewModel);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await _customerRepository.GetCustomerByID(id.Value);
             _customerRepository.UpdateCustomer(customer);
            
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerID,FirstName,LastName,StreetAddress,CityAddress,StateAddress,CountryAddress,UserName,Email,PassWord,RegDate")] CustomerViewModel customerViewModel)
        {
            if (id != customerViewModel.CustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var customer = new Customer()
                    {
                        CustomerID = customerViewModel.CustomerID,
                        FirstName = customerViewModel.FirstName,
                        LastName = customerViewModel.LastName,
                        StreetAddress = customerViewModel.StreetAddress,
                        CityAddress = customerViewModel.CityAddress,
                        StateAddress = customerViewModel.StateAddress,
                        CountryAddress = customerViewModel.CountryAddress,
                        UserName = customerViewModel.UserName,
                        PassWord = customerViewModel.PassWord,
                        RegDate = customerViewModel.RegDate,
                        Email = customerViewModel.Email
                    };
                    _customerRepository.UpdateCustomer(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerViewModelExists(customerViewModel.CustomerID))
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
            return View(customerViewModel);
        }
        public async Task<IActionResult> OrderHistory(int? id)
        {
            
            var orders = await _orderRepository.GetCustomerHist(id.Value);
            if (orders == null)
            {
                return NotFound();
            }
            var orderViews = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                orderViews.Add(new OrderViewModel
                {
                    Order = order
                });
            }

            return View(orderViews);
        }
        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = await _customerRepository.GetCustomerByID(id.Value);
               
            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int CustomerID)
        {
            _customerRepository.DeleteCustomer(CustomerID);
            return RedirectToAction(nameof(Index));
        }



        private bool CustomerViewModelExists(int id)
        {
            var customer = _customerRepository.GetCustomerByID(id);
            if (customer == null)
                return false;
            return true;
        }

    }
}
