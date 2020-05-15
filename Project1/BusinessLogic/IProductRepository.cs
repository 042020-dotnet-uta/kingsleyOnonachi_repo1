using MvcProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.BusinessLogic
{
    interface IProductRepository : IDisposable
    {
        IEnumerable<Inventory> GetAllProductsStore(int storeId);
        Inventory GetProductById(int productId);
        int AddProductToStore(Inventory product);
        int GetQuantityProduct(int productId);
        double GetUnitPrice(int productId);
        int UpdateProductInfo(Inventory product);


    }
}
