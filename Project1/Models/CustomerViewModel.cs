﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.Models
{
    public class CustomerViewModel
    {
        [Key]
        [DisplayName("ID")]
        public int CustomerID { get; set; }

        [Required]

        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Street Address")]
        [Display(Name = "Street")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Please Enter City")]
        [Display(Name = "City")]
        public string CityAddress { get; set; }

        [Required(ErrorMessage = "Please Enter State")]
        [Display(Name = "State")]
        public string StateAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Country")]
        [Display(Name = "Country")]
        public string CountryAddress { get; set; }
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Name = "Email Address")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PassWord { get; set; }

        [Display(Name = "Date of Regisration")]
        [DataType(DataType.Date)]
        public DateTime RegDate { get; set; }



        public virtual ICollection<Defaultstore> Defaultstore { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}