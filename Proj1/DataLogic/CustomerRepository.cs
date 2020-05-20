using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Proj1.BusinessLogic;
using Proj1.Data;
using Proj1.Models;

namespace Proj1.DataLogic
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Proj1Context _context;

        public CustomerRepository(Proj1Context context)
        {
            this._context = context;
        }

        public async void DeleteCustomer(int Id)
        {
            if(Id >= 0) 
            { 
                var customer = await _context.Customer
                                .Where(c => c.CustomerID == Id)
                                .FirstOrDefaultAsync();
                _context.Customer.Remove(customer);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerByFname(string firstName)
        {
            if (firstName != null)
            {
                Customer customer = await _context.Customer
                                    .Where(c => c.FirstName == firstName)
                                    .FirstOrDefaultAsync();
                if (customer == null)
                {
                    return NotFoundException();
                }
                return customer;
            }
            return NotFoundException();
        }
        public async Task<IEnumerable<Customer>> Find(Expression<Func<Customer, bool>> predicate)
        {
            return await _context.Customer
               .AsNoTracking()
               .AsQueryable()
               .Where(predicate)
               .ToListAsync();
        }
        private Customer NotFoundException()
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetCustomerByFnameLname(string firstName, string LastName)
        {

            if (firstName != null)
            {
                Customer customer = await _context.Customer
                                    .Where(c => c.FirstName == LastName)
                                    .FirstOrDefaultAsync();
                if (customer == null)
                {
                    return NotFoundException();
                }
                return customer;
            }
            return NotFoundException();
        }

        public async Task<Customer> GetCustomerByUserNameAsync(string userName)
        {
            //using project0Context context = new project0Context();
            ///Here customer information is returned if supplied iit's username
            ///Input: customer' username
            ///Output: custommer
            if (userName == null)//check that the input is not null
            {
                return NotFoundException();
            }
            var customer = await _context.Customer.FirstOrDefaultAsync(c => c.UserName == userName);

            if (customer == null)//check if the return value contain some information
            {
                return NotFoundException();
            }

            return customer;
        }
        public Customer UserLogin(string email, string password)
        {
            var userlogin = _context.Customer.Where(c => c.Email == email && c.PassWord==password).FirstOrDefault();

            return userlogin;
        }
        public async Task <Customer> GetCustomerByID(int Id)
        {

            
            ///Here customer information is returned if supplied iit's customer id
            ///Input: customerId
            ///Output: custommer

            if (Id <= 0)
            {
                return NotFoundException();
            }
            var customer =await  _context.Customer.FirstOrDefaultAsync(c => c.CustomerID == Id);
            if (customer == null)
            {
                return NotFoundException();
            }


            return customer;
        }

        public async Task<CustomerViewModel> GetCustomerViewByID(int Id)
        {

            //using project0Context context = new project0Context();
            ///Here customer information is returned if supplied iit's customer id
            ///Input: customerId
            ///Output: custommer

            if (Id <= 0)
            {
                return null;
            }
            var customer =await _context.Customer.FirstOrDefaultAsync(c => c.CustomerID == Id);
            if (customer == null)
            {
                throw null;
            }
            var customerView = new CustomerViewModel
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                StreetAddress = customer.StreetAddress,
                CityAddress = customer.CityAddress,
                StateAddress = customer.StateAddress,
                CountryAddress = customer.CountryAddress,
                UserName = customer.UserName,
                Email = customer.Email,
                PassWord = customer.PassWord,
                RegDate = customer.RegDate
            };

            return customerView;
        }
        public List<Customer> GetAllCustomers()
        {
            var customers =  _context.Customer.ToList();
            if (customers == null)
            {
                throw NotFound();
            }

            return customers;
        }

        private Exception NotFound()
        {
            throw new NotImplementedException();
        }

        public int AddCustomer(Customer customer)
        {
            int result = -1;
            if (customer != null)
            {
                _context.Customer.Add(customer);
                _context.SaveChanges();
                result = customer.CustomerID;
            }
            return result;
        }

        public void UpdateCustomer(Customer customer)
        {
            

            if (customer != null)
            {
                //_context.Entry(customer).State = EntityState.Modified;
                _context.Customer.Update(customer);
                _context.SaveChanges();
                
            }
           
        }

        public int GetCustomerIdByEmail(string email)
        {
            if(email == null)
            {
                return -1;
            }

            var customer =  _context.Customer.FirstOrDefault(c => c.Email == email);

            return customer.CustomerID;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //dispose managed state (managed objects).
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CustomerRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

    internal class T
    {
    }
}
