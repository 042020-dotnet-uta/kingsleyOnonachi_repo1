using Microsoft.AspNetCore.Identity;
using MvcProject1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.Data
{
    public class Store
    {
        public Store()
        {
            Inventory = new HashSet<Inventory>();
        }
        [Key]
        public int StoreID { get; set; }

        public string StreetAddress { get; set; }
        public string CityAddress { get; set; }
        public string StateAddress { get; set; }
        public string CountryAddress { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}