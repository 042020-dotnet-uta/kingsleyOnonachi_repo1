using Proj1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace Proj1.Models
{
    public class CustomerViewModel
    {
        public readonly IEnumerable<Customer> Customers;

        [Key]
        [DisplayName("ID")]
        public int CustomerID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter First Name")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Street Address")]
        [Display(Name = "Street")]
        public string StreetAddress { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter City")]
        [Display(Name = "City")]
        public string CityAddress { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter State")]
        [Display(Name = "State")]
        public string StateAddress { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage = "Please Enter Country")]
        [Display(Name = "Country")]
        public string CountryAddress { get; set; }
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Email Address")]
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
    }
}