using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.Data
{
    public class Orderlist
    {
        [Key]
        public int OrderlistID { get; set; }
        public int OrderID { get; set; }
        public int InventoryID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public virtual Orders Order { get; set; }
    }
}