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
    public class OrderListRepository : IOrderListRepository
    {
        public int ID { get; set; }
        private readonly Proj1Context _context;

        public OrderListRepository(Proj1Context context)
        {
            _context = context;
        }
        public void AddOrderlist(OrderList orderitem)
        {
            if(orderitem != null)
            {
                _context.Orderlist.Add(orderitem);
                _context.SaveChanges();
            }
        }

        public async Task <IEnumerable<OrderList>> GetOrderlists(int orderid)
        {
            return await _context.Orderlist.Where(o => o.OrderID == orderid).ToListAsync();
        }

        //public async Task <IEnumerable<OrderList>>GetOrder

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


                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~OrderListRepository()
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
