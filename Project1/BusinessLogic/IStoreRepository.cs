using MvcProject1.Data;
using MvcProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.BusinessLogic
{
    public interface IStoreRepository : IDisposable
    {
        IEnumerable<Store> GetAllStore();
        Store GetStoreById(int storeId);
        int AddStore(Store store);
        int UpdateStore(Store store);
        void DeleteStore(int storeId);

    }
}
