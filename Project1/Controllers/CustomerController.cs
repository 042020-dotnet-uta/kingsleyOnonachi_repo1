using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcProject1.BusinessLogic;
using MvcProject1.Data;
using MvcProject1.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MvcProject1.DataLogic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Diagnostics.Eventing.Reader;

namespace MvcProject1.Controllers
{
    public class CustomerController : Controller
    {

        
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        //private readonly SignInManager<Customer> _signManager;
        //private readonly UserManager<Customer> _userManager;


        public CustomerController(MvcProject1Context context, ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            //_userManager = userManager;
            //_signManager = signManager;
        }

        //public CustomerController(ICustomerRepository @object)
        //{
        //    this.@object = @object;
        //}

        public IActionResult Index()
        {
            return View();
        }

        //Registration Action
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        //Registration Post Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind]CustomerViewModel customerV)
        {
            bool Status = false;
            string Message = "";

            //Model Validation
            if (ModelState.IsValid)
            {
                //Email exist
                bool IsExist = IsEmailExist(customerV.Email);
                if (IsExist)
                {
                    ModelState.AddModelError("EmailExist", "Email Already exist!");
                    return View();

                }


                //Password hashing
                customerV.PassWord = Crypto.Hash(customerV.PassWord);
                var customer = new Customer
                {
                    CustomerID = customerV.CustomerID,
                    FirstName = customerV.FirstName,
                    LastName = customerV.LastName,
                    StreetAddress = customerV.StreetAddress,
                    CityAddress = customerV.CityAddress,
                    StateAddress = customerV.StateAddress,
                    CountryAddress = customerV.CountryAddress,
                    UserName = customerV.UserName,
                    Email = customerV.Email,
                    PassWord = customerV.PassWord,
                    RegDate = customerV.RegDate

                };

                _customerRepository.AddCustomer(customer);
                Message = "Registration is Sucessful, Thank for Shopping with Us";
                Status = true;
            }
            else
            {
                Message = "Invalid Request";
            }
            ViewData["Message"] = Message;
            ViewData["Status"] = Status;
            return RedirectToAction("Index");
        }
        

        //[HttpGet]
        //public IActionResult Login()
        //{
        //    if(Session[""])

        //    return View();
        //}
        //[HttpPost]
        public IActionResult Login(string UserName, string password)
        {
            //int id = _customerRepository.GetCustomerIdByEmail(email);

            //var customerClaims = new List<Claim>
            //{
            //    new Claim("ID", id.ToString())

            //};

            //var customerIdentity = new ClaimsIdentity(customerClaims, "Customer Identity");

            //var userPrincipal = new ClaimsPrincipal(new[] { customerIdentity });

            //HttpContext.SignInAsync(userPrincipal);
            string pw = Crypto.Hash(password);
            var UserLogin = _customerRepository.UserLogin(UserName, pw);

            return RedirectToAction("Index");
        }
        [HttpGet]
        //public IActionResult MyOrders()
        //{
        //    return View();
        //}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerView = _customerRepository.GetCustomerByID(id.Value);

            if (customerView == null)
            {
                return NotFound();
            }
            return View(customerView);
        }
        [HttpGet]
        public IActionResult MyOrderIndex(DateTime SearchString)
        {
            var myOrdersearch = _orderRepository.GetOrderOfDay(SearchString);

            var orderView = new OrderListViewModel
            {
                Orders = myOrdersearch.ToList()
            };
            return View(orderView);
        }
        [HttpPost]
        public IActionResult MyOrders()
        {

            var id = User.FindFirstValue("ID");
            if(id == null)
            {
                return View("Index");
            }

            var myOrders = _orderRepository.GetCustomerHist(int.Parse(id));
            var orderViewModel = new OrderListViewModel
            {
                Orders = myOrders.ToList()
            };

            return View(orderViewModel);
        }

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            IEnumerable<Customer> dc = _customerRepository.GetAllCustomers();
            var v = dc.Where(c => c.Email == emailID).FirstOrDefault();
            if (v != null)
                return true;
            return false;
        }


    }
}