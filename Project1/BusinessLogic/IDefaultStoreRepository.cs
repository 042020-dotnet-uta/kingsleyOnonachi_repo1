using MvcProject1.Data;
using MvcProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.BusinessLogic
{
    public interface IDefaultStoreRepository
    {
        public List<Customer> GetAllCustomerOfStore(int storeId);
        public int TotalOfStoreCustomers(int storeId = 1);
        Task <Store> GetCustomerDefaultStore(int customerId);
    }
}
