using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Proj1.BusinessLogic;
using Proj1.Data;
using Proj1.Helpers;
using Proj1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proj1.Controllers
{
    public class CustomerLoginController : Controller
    {
        // GET: /<controller>/
        private readonly ICustomerRepository _customerRepo;
        public CustomerLoginController(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(CustomerLoginModel customerLogin)
        {
            if (ModelState.IsValid)
            {
                var cust = _customerRepo.UserLogin(customerLogin.EmailID,Crypto.Hash(customerLogin.Password));

                if (cust != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateNew()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateNew(Customer user)
        {
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    var custID = _customerRepo.AddCustomer(user);
                    var cust = _customerRepo.GetCustomerByID(custID);

                    CreateClaimIdentity(user.Email);
                    AddUserToSession(await cust);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(user);
        }

        public async Task<IActionResult> LoggedIn(Customer customer)
        {
            return View();
        }

        private async void CreateClaimIdentity(string email)
        {
            var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Role, email.StartsWith("admin") ? "Admin" : "Customer")
                };
            var identity = new ClaimsIdentity(userClaims, "User Identity");

            var userPrincipal = new ClaimsPrincipal(new[] { identity });
            await HttpContext.SignInAsync(userPrincipal);
        }
        private void AddUserToSession(Customer cust)
        {
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Customer", cust);
        }
    }
}
