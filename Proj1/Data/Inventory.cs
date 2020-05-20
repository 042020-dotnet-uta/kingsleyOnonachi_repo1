using Microsoft.AspNetCore.Identity;
using Proj1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proj1.Data
{
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }

        public int StoreID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ListPrice { get; set; }

        public virtual Store Store { get; set; }
        public int? ID { get; internal set; }
    }
}
