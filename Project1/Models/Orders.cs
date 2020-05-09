using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject1.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double Total { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual ICollection<Orderlist> Orderlist { get; set; }
    }
}