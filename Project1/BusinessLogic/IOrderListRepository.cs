using MvcProject1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.BusinessLogic
{
    public interface IOrderListRepository : IDisposable
    {
        void AddOrderlist(Orderlist orderitem);
        IEnumerable<Orderlist> GetOrderlists(int orderid);

    }
}
