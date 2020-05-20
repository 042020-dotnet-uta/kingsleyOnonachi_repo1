using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Proj1.Data
{
    public class Customer
    {
        public Customer()
        {
            Defaultstore = new HashSet<DefaultStore>();
            Orders = new HashSet<Order>();
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
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PassWord { get; set; }

        [Display(Name = "Date of Regisration")]
        [DataType(DataType.Date)]
        public DateTime RegDate { get; set; }



        public virtual ICollection<DefaultStore> Defaultstore { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public static implicit operator List<object>(Customer v)
        {
            throw new NotImplementedException();
        }
    }
}
