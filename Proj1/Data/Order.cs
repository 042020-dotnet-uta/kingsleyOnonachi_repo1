using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proj1.Data;

namespace Proj1.Data
{
    public class Order
    {
        public Order()
        {
            Orderlist = new List<OrderList>();
        }
        [Key]
        public int OrderID { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        [ForeignKey("Store")]
        public int StoreID { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double Total { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual List<OrderList> Orderlist { get; set; }
        public virtual Store Store { get; set; }
       
    }
}