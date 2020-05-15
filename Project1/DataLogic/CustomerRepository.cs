using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MvcProject1.BusinessLogic;
using MvcProject1.Data;
using MvcProject1.Models;

namespace MvcProject1.DataLogic
{
    public class CustomerRepository : ICustomerRepository
    {
        private MvcProject1Context _context;

        public CustomerRepository(MvcProject1Context context)
        {
            this._context = context;
        }

        public async void DeleteCustomer(int Id)
        {
            if(Id <= 0) 
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

        public async Task<Customer> GetCustomerByID(int Id)
        {

            //using project0Context context = new project0Context();
            ///Here customer information is returned if supplied iit's customer id
            ///Input: customerId
            ///Output: custommer

            if (Id <= 0)
            {
                return NotFoundException();
            }
            var customer = await _context.Customer.FirstOrDefaultAsync(c => c.CustomerID == Id);
            if (customer == null)
            {
                return NotFoundException();
            }


            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = await _context.Customer.ToListAsync();
            if (customers == null)
            {
               
            }

            return customers;
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

        public int UpdateCustomer(Customer customer)
        {
            int result = -1;

            if (customer != null)
            {
                _context.Entry(customer).State = EntityState.Modified;
                _context.SaveChanges();
                result = customer.CustomerID;
            }
            return result;
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
}
