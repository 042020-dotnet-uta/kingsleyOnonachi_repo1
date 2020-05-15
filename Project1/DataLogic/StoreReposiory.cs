using Microsoft.EntityFrameworkCore;
using MvcProject1.BusinessLogic;
using MvcProject1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.DataLogic
{
    public class StoreReposiory : IStoreRepository
    {
        private MvcProject1Context _context;

        public StoreReposiory(MvcProject1Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Store>> GetAllStore()
        {
            return await _context.Store.ToListAsync();
        }

        public  Store GetStoreById(int storeId)
        {
            return  _context.Store.Find(storeId);
        }

        public int AddStore(Store store)
        {
            int result = -1;
            if(store != null)
            {
                _context.Store.Add(store);
                _context.SaveChanges();
                result = store.StoreID;
            }
            return result;
        }

        public int UpdateStore(Store store)
        {
            int result = -1;
            if(store != null)
            {
                _context.Entry(store).State = EntityState.Modified;
                _context.SaveChanges();
                result = store.StoreID;
            }
            return result;
        }

        public void DeleteStore(int storeId)
        {
            Store store = _context.Store.Find(storeId);
            _context.Store.Remove(store);
            _context.SaveChanges();
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
