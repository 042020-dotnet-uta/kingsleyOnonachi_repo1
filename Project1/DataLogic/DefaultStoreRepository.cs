using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcProject1.BusinessLogic;
using MvcProject1.Data;
using MvcProject1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.DataLogic
{
    public class DefaultStoreRepository : IDefaultStoreRepository
    {
        //Menu menu = new Menu();
        private readonly MvcProject1Context _context;
        public DefaultStoreRepository(MvcProject1Context context)
        {
            _context = context;

        }

        /// <summary>
        /// get all the customers in a store
        /// input: store id and Dbcontext
        /// output: list of all customer of a given store
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storeId"></param>
        /// <returns name="storeCustomers"></returns>
        public  List<Customer>GetAllCustomerOfStore(int storeId)
        {
            var storeCustomers = new List<Customer>();
            var custid =  _context.Defaultstore
                .Where(c => c.StoreID == storeId)
                .Select(c => c.CustomerID)
                .ToList();
            foreach (var cuid in custid)
            {
                var customers = _context.Customer
                    .Where(c => c.CustomerID == cuid)
                    .FirstOrDefault();
                storeCustomers.Add(customers);
            }

            return storeCustomers;
        }
        /// <summary>
        /// Return the number of customers a store location has
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storeId"></param>
        /// <returns name="customer count"></returns>
        public int TotalOfStoreCustomers(int storeId)
        {
            var custId = _context.Defaultstore
                .Where(ds => ds.StoreID == storeId).ToList();
            
            return custId.Count;
        }

    
        /// <summary>
        /// Get the customer's default store location of a customer
        /// </summary>
        /// <param name="context"></param>
        /// <param name="customerId"></param>
        /// <returns name="storeId"></returns>
        public Task<Store> GetCustomerDefaultStore(int customerId)
        {
            if(customerId <= 0)
            {
                throw InvalidOperationException("Invalid Id given");
            }
            var storeID =  _context.Defaultstore.FirstOrDefault(s => s.CustomerID == customerId);
            var store = _context.Store.FirstOrDefaultAsync(s => s.StoreID == storeID.StoreID);
 
            return store;
        }

        private Exception InvalidOperationException(string v)
        {
            throw new NotImplementedException();
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~StoreReposiory()
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
