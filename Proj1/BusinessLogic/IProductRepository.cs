using Proj1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj1.BusinessLogic
{
    public interface IProductRepository : IDisposable
    {
        Task <IEnumerable<Inventory>> GetAllProducts();
        Task <IEnumerable<Inventory>> GetAllProductsStore(int storeId);
        Task <Inventory> GetProductById(int productId);
        Task <Inventory> GetProductByName(string name);
        Task <Inventory> GetProductByDescription(string description);
        int AddProductToStore(Inventory product);
        void DeleteProduct(Inventory product);
        int GetQuantityProduct(int productId);
        decimal GetUnitPrice(int productId);
        int UpdateProductInfo(Inventory product);
        

    }
}