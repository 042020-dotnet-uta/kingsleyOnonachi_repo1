using Microsoft.AspNetCore.Mvc.Rendering;
using Proj1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proj1.Models
{
    public class AdmCustomerViewModel
    {
        [Key]
        public int ID { get; set; }
        public List<Customer> Customers { get; set; }

        public SelectList SearchTypeList { get; set; }

        public int SearchType { get; set; }
        public string SearchString { get; set; }
    }
}
