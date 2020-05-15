using MvcProject1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.BusinessLogic
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Inventory> GetAllProductsStore(int storeId);
        Inventory GetProductById(int productId);
        int AddProductToStore(Inventory product);
        int GetQuantityProduct(int productId);
        decimal GetUnitPrice(int productId);
        int UpdateProductInfo(Inventory product);


    }
}
