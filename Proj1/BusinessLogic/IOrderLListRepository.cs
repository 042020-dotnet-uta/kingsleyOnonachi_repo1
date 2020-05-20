using Proj1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj1.BusinessLogic
{
    public interface IOrderListRepository : IDisposable
    {
        void AddOrderlist(OrderList orderitem);
        Task <IEnumerable<OrderList>> GetOrderlists(int orderid);

    }
}
