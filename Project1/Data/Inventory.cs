using Microsoft.AspNetCore.Identity;
using MvcProject1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }

        public int StoreID { get; set; }
        public int Quantity { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double ListPrice { get; set; }

        public virtual Store Store { get; set; }

    }
}
