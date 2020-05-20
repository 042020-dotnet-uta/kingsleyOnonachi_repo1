using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject1.Data
{
    public class Orders
    {
        public Orders()
        {
            Orderlist = new HashSet<Orderlist>();
        }
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double Total { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Orderlist> Orderlist { get; set; }
        public int? ID { get; internal set; }
    }
}