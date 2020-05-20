using Microsoft.EntityFrameworkCore;
using Proj1.BusinessLogic;
using Proj1.Data;
using Proj1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj1.DataLogic
{
    public class StoreRepository : IStoreRepository
    {
        private readonly Proj1Context _context;

        public StoreRepository(Proj1Context context)
        {
            _context = context;
        }
        public async Task <IEnumerable<Store>> GetAllStore()
        {
            return await _context.Store.ToListAsync();
        }

        public async Task <Store> GetStoreById(int storeId)
        {
            return  await _context.Store.FindAsync(storeId);
        }

        public async Task <int> AddStore(Store store)
        {
            int result = -1;
            if(store != null)
            {
                _context.Store.Add(store);
                await _context.SaveChangesAsync();
                result = store.StoreID;
            }
            return result;
        }

        public async Task <int> UpdateStore(Store store)
        {
            int result = -1;
            if(store != null)
            {
                _context.Entry(store).State = EntityState.Modified;
                await _context.SaveChangesAsync();
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
