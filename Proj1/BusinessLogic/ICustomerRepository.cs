using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Proj1.Data;
using Proj1.Models;

namespace Proj1.BusinessLogic
{
    public interface ICustomerRepository : IDisposable
{
        List<Customer> GetAllCustomers();
        Task <Customer> GetCustomerByID(int Id);
        Task <Customer>GetCustomerByFname(string firstName);
        Task <Customer>GetCustomerByFnameLname(string firstName, string LastName);
        Task<Customer> GetCustomerByUserNameAsync(string userName);
        int AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerID);
        int GetCustomerIdByEmail(string email);
        Task<CustomerViewModel> GetCustomerViewByID(int Id);
        Customer UserLogin(string email, string password);
        
    }
}
