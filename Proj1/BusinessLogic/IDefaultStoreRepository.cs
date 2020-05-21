using Proj1.Data;
using Proj1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj1.BusinessLogic
{
    public interface IDefaultStoreRepository : IDisposable
    {
        public Task <List<Customer>> GetAllCustomerOfStore(int storeId);
        public int TotalOfStoreCustomers(int storeId = 1);
        Task <Store> GetCustomerDefaultStore(int customerId);
        Task <DefaultStore> UpdateDefaultStore(DefaultStore defaultStore);
        Task<DefaultStore>AddDefaultStore(DefaultStore defaultStore);

    }
}
