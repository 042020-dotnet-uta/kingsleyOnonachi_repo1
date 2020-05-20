using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcProject1.Data;
using MvcProject1.Models;

namespace MvcProject1.BusinessLogic
{
    public interface ICustomerRepository : IDisposable
{
        IEnumerable<Customer> GetAllCustomers();
        Task <Customer> GetCustomerByID(int Id);
        Task <Customer>GetCustomerByFname(string firstName);
        Task <Customer>GetCustomerByFnameLname(string firstName, string LastName);
        Task<Customer> GetCustomerByUserNameAsync(string userName);
        int AddCustomer(Customer customer);
        int UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerID);
        int GetCustomerIdByEmail(string email);
        Task<CustomerViewModel> GetCustomerViewByID(int Id);
        Customer UserLogin(string userName, string password);

    }
}
