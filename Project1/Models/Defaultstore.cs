using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcProject1.Models
{
    public class Defaultstore
    {
        [Key]
        public int DefaultStoreID { get; set; }
        public int CustomerID { get; set; }

        [Display(Name = "Date of Regisration")]
        [DataType(DataType.Date)]
        public DateTime RegDate { get; set; }

        public int StoreID { get; set; }

        public virtual Customers Customer { get; set; }
    }
}