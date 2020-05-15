using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcProject1.Data
{
    public class Customer
    {
        public Customer()
        {
            Defaultstore = new HashSet<Defaultstore>();
            Orders = new HashSet<Orders>();
        }
        [Key]
        public int CustomerID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string CityAddress { get; set; }
        [Required]
        public string StateAddress { get; set; }
        [Required]
        public string CountryAddress { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Name = "Email Address")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PassWord { get; set; }

        [Display(Name ="Date of Regisration")]
        [DataType(DataType.Date)]
        public DateTime RegDate { get; set; }

       

        public virtual ICollection<Defaultstore> Defaultstore { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

    }
}
