using Microsoft.AspNetCore.Mvc.Rendering;
using MvcProject1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.Models
{
    public class InventoryViewModel
    {
        [Key]
        public int InventoryID { get; set; }
        public List<Inventory> Products { get; set; }
        public SelectList StoreLocation { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SearchString { get; set; }
    }
}
