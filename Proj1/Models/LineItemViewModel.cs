using Proj1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proj1.Models
{
    public class LineItemViewModel
    {
        public int ID { get; set; }
        public OrderList OrderList { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total
        {
            get => OrderList.Price * OrderList.Quantity;
            set { }
        }
    }
}