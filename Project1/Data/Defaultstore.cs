using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcProject1.Data;

namespace MvcProject1.Data
{
    public class Defaultstore
    {
        [Key]
        public int DefaultStoreID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public int StoreID { get; set; }
        [Display(Name = "Date of Regisration")]
        [DataType(DataType.Date)]
        public DateTime RegDate { get; set; }
       

        public virtual Customer Customer { get; set; }
        
    }
}