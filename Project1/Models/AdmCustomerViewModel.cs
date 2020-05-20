using Microsoft.AspNetCore.Mvc.Rendering;
using MvcProject1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcProject1.Models
{

    public class AdmCustomerViewModel
    {
        
        [Key]
        public int ID { get; set; }
        public List<Customer> Customers { get; set; }
        SelectList StoreLocation { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string SearchString { get; set; }
        public string CityLocation { get; set; }
    }
}
