using MvcProject1.BusinessLogic;
using MvcProject1.Data;
using MvcProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.DataLogic
{
    public class OrderRepository : IOrderRepository
    {
        private MvcProject1Context _context;

        public OrderRepository(MvcProject1Context context)
        {
            _context = context;
        }
        public IEnumerable<Orders> GetAllOrders()
        {
            return _context.Order.ToList();
        }

        public IEnumerable<Orders> GetOrderOfDay(DateTime orderdate)
        {
           if(orderdate == null)
            {
                throw new NullReferenceException();
            }

            return _context.Order.Where(o => o.OrderDate == orderdate).ToList();
        }

        public IEnumerable<Orders> GetCustomerHist(int customerID)
        {
            if(customerID == 0)
                throw new NotImplementedException();
            return _context.Order.Where(o => o.CustomerId == customerID).ToList();
        }

        public int AddOrder(Orders order)
        {
            int result = -1;
            if(order != null)
            {
                _context.Order.Add(order);
                _context.SaveChanges();
                result = order.OrderId;
            }
            return result;
        }

        public IEnumerable<Orders> GetStoreOrder(int storeId)
        {
            var defaultst = _context.Defaultstore.ToList();
            var orderitem = _context.Order.ToList();
            var orderQuery =
                from order in orderitem
                join defa in defaultst on order.CustomerId equals defa.CustomerID into so
                from s in so.Where(defa => defa.StoreID == storeId).DefaultIfEmpty()
                select order;
            return orderQuery;
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

        #endregion
    }
}
