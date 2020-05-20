using Microsoft.AspNetCore.Mvc.Rendering;
using Proj1.Data;
using Proj1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Proj1.Models
{
    public class NewOrderViewModel
    {
        public int ID { get; set; }
        public Customer Customer { get; set; }
        public int StoreId { get; set; }
        public SelectList StoreLocations { get; set; }

        public Store SelectedStore { get; set; }

        public int SelectedProduct { get; set; }
        public int SelectedQuantity { get; set; }
        public List<LineItemViewModel> SelectedProducts { get; set; }

        public decimal Total 
        {
            get
            {
                var total = 0.0M;
                if (SelectedProducts != null)
                {
                    foreach (var item in SelectedProducts)
                    {
                        total += item.Total;
                    }
                }
                return total;
            }
            set { }
        }

        public NewOrderViewModel() { SelectedProducts = new List<LineItemViewModel>(); } 
    }
}