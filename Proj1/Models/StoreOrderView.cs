using Microsoft.AspNetCore.Mvc.Rendering;
using Proj1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj1.Models
{
    public class StoreOrderView
    {
       
        public int ID { get; set; }
        public List<Store> Store { get; set; }
        public List<Order> Order { get; set; }

        public SelectList StoreLocation { get; set; }

        
    }
}
