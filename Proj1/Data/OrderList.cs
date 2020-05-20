using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proj1.Data
{
    public class OrderList
    {
        public int OrderListID { get; set; }
       
        public int OrderID { get; set; }
        
        public int InventoryID { get; set; }
        public virtual Inventory Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public virtual Order Order { get; set; }
       
    }
}