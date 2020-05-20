using Microsoft.AspNetCore.Mvc.Rendering;
using Proj1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
namespace Proj1.Models
{
    public class OrderListViewModel
    {
        [Key]
        [Display(Name = "Order Number")]
        public int OrderID { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDateTime { get; set; }

        public Customer Customer { get; set; }
        public Store Store { get; set; }

        [Display(Name = "Total Items")]
        public int TotalItems
        {
            get
            {
                var total = 0;
                foreach (var lineItem in LineItems)
                {
                    total += (lineItem.OrderList.Quantity);
                }

                return total;
            }
            set { }
        }

        [DataType(DataType.Currency)]
        [Display(Name = "Total Sale")]
        public decimal TotalSale
        {
            get
            {
                var total = 0.0m;
                foreach (var lineItem in LineItems)
                {
                    total += (lineItem.Total);
                }

                return total;
            }

            set { }
        }

        public List<LineItemViewModel> LineItems { get; set; }

        public OrderListViewModel() { LineItems = new List<LineItemViewModel>(); 
        }
    }
}