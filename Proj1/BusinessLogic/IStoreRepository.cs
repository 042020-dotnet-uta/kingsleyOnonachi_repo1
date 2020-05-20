using Proj1.Data;
using Proj1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj1.BusinessLogic
{
    public interface IStoreRepository : IDisposable
    {
        Task <IEnumerable<Store>> GetAllStore();
        Task <Store> GetStoreById(int storeId);
        Task <int> AddStore(Store store);
        Task <int> UpdateStore(Store store);
        void DeleteStore(int storeId);

    }
}
