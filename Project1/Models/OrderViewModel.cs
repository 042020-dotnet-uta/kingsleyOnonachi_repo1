
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcProject1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.Models
{
    public class OrderViewModel
    {
        [Key]
        public int OrderID { get; set; }
        public List<Orders> Orders { get; set; }
        public List<Orderlist>Orderlists  { get; set; }
        public SelectList dateOfOrder { get; set; }
        public SelectList OrderTotal { get; set; }
    }
}
