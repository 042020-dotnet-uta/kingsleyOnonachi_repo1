using Proj1.Data;
using Proj1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj1.Models
{
    public class CartItem
    {
        public int ID { get; set; }
         public Inventory Product { get; set; }

        public int Quantity { get; set; }
    }
    
}