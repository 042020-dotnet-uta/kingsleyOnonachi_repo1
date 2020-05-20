using Proj1.Data;
using Proj1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Proj1.Models
{
    public class OrderViewModel
    {
        [Key]
        public int ID { get; set; }
        public Order Order { get; set; }

        [Display(Name = "Total Items")]
        public int TotalItems 
        { 
            get
            {
                var total = 0;
                foreach (var lineItem in Order.Orderlist)
                {
                    total += lineItem.Quantity;
                }

                return total;
            }
            set { }
        }

        [DataType(DataType.Currency)]
        [Display(Name = "Total Sale")]
        public double TotalSale 
        {
            get 
            {
                return Order.Total;
            }

            set { } 
        }
    }
}