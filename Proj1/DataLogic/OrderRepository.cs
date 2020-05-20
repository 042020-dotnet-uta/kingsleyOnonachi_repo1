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
    public class OrderRepository : IOrderRepository
    {
        private readonly Proj1Context _context;

        public OrderRepository(Proj1Context context)
        {
            _context = context;
        }
        public async Task <IEnumerable<Order>> GetAllOrders()
        {
            return await _context.Order.ToListAsync();
        }

        public async Task <IEnumerable<Order>> GetOrderOfDay(DateTime orderdate)
        {
           if(orderdate == null)
            {
                throw new NullReferenceException();
            }

            return await _context.Order.Where(o => o.OrderDate == orderdate).ToListAsync();
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            var _order = await _context.Order
                .Include(o => o.Orderlist)
                .Include(o => o.Store)
                .Include(o => o.Customer)
                .SingleAsync(o => o.OrderID == order.OrderID);
            _context.Update(order);
            return order;
        }
        public async Task <IEnumerable<Order>> GetCustomerHist(int customerID)
        {
            if(customerID == 0)
                throw new NotImplementedException();
            return await _context.Order.Where(o => o.CustomerID == customerID).ToListAsync();
        }

        public async Task<Order>AddOrder(Order order)
        {
            
            //Check to make sure there is enough inventory
            foreach (var item in order.Orderlist)
            {
                if (!(CheckForEnoughInventory(order.StoreID, item.InventoryID, item.Quantity)))
                    throw new ArgumentOutOfRangeException($"Not enough inventory for product with ID {item.InventoryID}");
            }
                _context.Order.Add(order);
            //decrement the appropriate inventories
            foreach (var item in order.Orderlist)
            {
                UpdateLocationQuantity(order.StoreID, item.InventoryID, (item.Quantity * -1));
            }
            _context.SaveChanges();
       
            return order;
        }

        public async Task <IEnumerable<Order>> GetStoreOrder(int storeId)
        {
        
            var orderitem = await _context.Order.Where(o=>o.StoreID==storeId).ToListAsync();
            
            return orderitem;
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
        // ~CustomerRepository()
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

        public async Task <Order> GetOrderById(int orderId)
        {
            return await _context.Order.FindAsync(orderId);
        }

        #endregion

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderID == id);
        }

        private bool CheckForEnoughInventory(int storeId, int prodId, int quantity)
        {
            var inventory = (from inv in _context.Inventory
                             where inv.StoreID == storeId && inv.InventoryID == prodId
                             select inv).AsNoTracking().Take(1).FirstOrDefault();

            return inventory.Quantity >= quantity;
        }

        private void UpdateLocationQuantity(int storeId, int prodId, int quatitiyUpdate)
        {
            var inventory = (from inv in _context.Inventory
                             where inv.StoreID == storeId && inv.InventoryID == prodId
                             select inv).Take(1).FirstOrDefault();

            inventory.Quantity += quatitiyUpdate;
        }
    }
}
