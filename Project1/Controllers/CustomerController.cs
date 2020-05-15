using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcProject1.BusinessLogic;
using MvcProject1.Data;
using MvcProject1.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using RestSharp;

namespace MvcProject1.Controllers
{
    public class CustomerController : Controller
    {
        private MvcProject1Context _context;
        private ICustomerRepository _customerRepository;

        public CustomerController(MvcProject1Context context, ICustomerRepository customerRepository)
        {
            _context = context;
            _customerRepository = customerRepository;
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
                var IsExist = IsEmailExist(customerV.Email);
                if (IsExist)
                {
                    ModelState.AddModelError("EmailExist", "Email Already exist!");
                    return View(customerV);

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
            return View(customerV);
        }


        //Login Action
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //login Post action
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(CustomerLogin login)
        //{
        //    string message;
        //    var v = _context.Customer.Where(c => c.Email == login.EmailID).FirstOrDefault();
        //    if(v != null)
        //    {
        //        if(string.Compare(Crypto.Hash(login.Password), v.PassWord) == 0)
        //        {

        //            int timeout = login.RememberMe ? 525600 : 200;
        //            var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
        //            string encrypted = FormsAuthentication.Encrypt(ticket);
        //            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
        //            cookie.Expires = DateTime.Now.AddMinutes(timeout);
        //            cookie.HttpOnly = true;
        //            Response.Cookies.Add(cookie);

        //            if (Url.IsLocalUrl(ReturnUrl))
        //            {
        //                return Redirect(ReturnUrl);
        //            }
        //            else
        //            {
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        else
        //        {
        //            message = "Invalid credential provided";
        //        }
      
        //}
        //    ViewBag.Message = message;
        //    return View();
        //}

        ////logout
        //[Authorize]
        //[HttpPost]
        //public ActionResult Logout()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Login", "User");
        //}
        [NonAction]
        public bool IsEmailExist(string emailId)
        {
            var v = _context.Customer.Where(c => c.Email == emailId).FirstOrDefault();
            return v != null;
        }
    }
}