using Microsoft.AspNetCore.Mvc.Rendering;
using MvcProject1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcProject1.Models
{
    public class OrderListViewModel
    {
        [Key]
        public int ID { get; set; }
        public List<Orders> Orders { get; set; }
        System.Web.Mvc.SelectList SelectList { get; set; }
        //public SelectList StoreLocation { get; set; }
        public string SearchString { get; set; }
        public int CustomerID { get; set; }
    }
}