using MvcProject1.BusinessLogic;
using MvcProject1.Data;
using MvcProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.DataLogic
{
    public class OrderListRepository : IOrderListRepository
    {
        private MvcProject1Context _context;

        public OrderListRepository(MvcProject1Context context)
        {
            _context = context;
        }
        public void AddOrderlist(Orderlist orderitem)
        {
            if(orderitem != null)
            {
                _context.Orderlist.Add(orderitem);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Orderlist> GetOrderlists(int orderid)
        {
            return  _context.Orderlist.Where(o => o.OrderID == orderid).ToList();
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
