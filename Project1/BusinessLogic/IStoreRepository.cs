﻿using MvcProject1.Data;
using MvcProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.BusinessLogic
{
    interface IStoreRepository : IDisposable
    {
        Task <IEnumerable<Store>> GetAllStore();
        Store GetStoreById(int storeId);
        int AddStore(Store store);
        int UpdateStore(Store store);
        void DeleteStore(int storeId);

    }
}