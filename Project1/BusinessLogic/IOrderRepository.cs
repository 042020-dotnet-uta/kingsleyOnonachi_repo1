using MvcProject1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.BusinessLogic
{
    public interface IOrderRepository : IDisposable
    {
        IEnumerable<Orders> GetAllOrders();
        IEnumerable<Orders> GetOrderOfDay(DateTime orderdate); 
        IEnumerable<Orders> GetCustomerHist(int customerID);
        int AddOrder(Orders order);
        IEnumerable<Orders> GetStoreOrder(int storeId);
    }
}
