using Microsoft.EntityFrameworkCore;
using MvcProject1.BusinessLogic;
using MvcProject1.Data;
using MvcProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.DataLogic
{
    public class ProductRepository : IProductRepository
    {
        private MvcProject1Context _context;

        public ProductRepository(MvcProject1Context context)
        {
            _context = context;
        }
        public int AddProductToStore(Inventory product)
        {
            int result = -1;
            if(product != null)
            {
                _context.Inventory.Add(product);
                _context.SaveChanges();
                result = product.InventoryID;
            }
            return result;
        }

        public IEnumerable<Inventory> GetAllProductsStore(int storeId)
        {
            return _context.Inventory.Where(i => i.StoreID == storeId).ToList();
        }

        public Inventory GetProductById(int productId)
        {
            
            return _context.Inventory.Find(productId);
        }

        public int GetQuantityProduct(int productId)
        {
            int result = 0;
            if(productId <= 0)
            {
                var product = _context.Inventory.Find(productId);
                result = product.Quantity;
            }
            return result;
        }

        public decimal GetUnitPrice(int productId)
        {
            decimal result = 0.0M;
            if (productId <= 0)
            {
                var product = _context.Inventory.Find(productId);
                result = product.ListPrice;
            }
            return result;
        }

        public int UpdateProductInfo(Inventory product)
        {
            int result = -1;

            if (product != null)
            {
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
                result = product.InventoryID;
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
                    //  dispose managed state (managed objects).
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ProductRepository()
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
