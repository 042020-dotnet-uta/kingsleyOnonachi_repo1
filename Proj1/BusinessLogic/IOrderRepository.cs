using Proj1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj1.BusinessLogic
{
    public interface IOrderRepository : IDisposable
    {
        Task <IEnumerable<Order>> GetAllOrders();
        Task <IEnumerable<Order>> GetOrderOfDay(DateTime orderdate); 
        Task <IEnumerable<Order>> GetCustomerHist(int customerID);
        Task<Order> AddOrder(Order order);
        Task <IEnumerable<Order>> GetStoreOrder(int storeId);
        Task <Order> GetOrderById(int orderId);
        Task<Order> UpdateOrder(Order order);
    }
}
