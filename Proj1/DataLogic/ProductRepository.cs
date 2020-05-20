using Microsoft.EntityFrameworkCore;
using Proj1.BusinessLogic;
using Proj1.Data;
using Proj1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Proj1.DataLogic
{
    public class ProductRepository : IProductRepository
    {
        private readonly Proj1Context _context;

        public ProductRepository(Proj1Context context)
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
        public  async Task <IEnumerable<Inventory>> GetAllProducts()
        {
            var products = await _context.Inventory.ToListAsync();

            return products; 
        }
        public async Task <IEnumerable<Inventory>> GetAllProductsStore(int storeId)
        {
            return await _context.Inventory.Where(i => i.StoreID == storeId).ToListAsync();
        }

        public async Task <Inventory> GetProductById(int productId)
        {
            
            return await _context.Inventory.FindAsync(productId);
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
        public void DeleteProduct(Inventory product)
        {   
            if(product != null)
            {
                _context.Inventory.Remove(product);
                _context.SaveChanges();
            }
            else
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

        public async Task <Inventory> GetProductByName(string name)
        {
            return await _context.Inventory.Where(p => p.Name == name).FirstOrDefaultAsync();
        }

        public async Task <Inventory> GetProductByDescription(string description)
        {
            if(description == null)
            {
                throw new NotImplementedException();
                
            }
            return await _context.Inventory.Where(p => p.Description == description).FirstOrDefaultAsync();
        }

      

     

       
        #endregion
    }
}
