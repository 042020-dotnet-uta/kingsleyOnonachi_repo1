using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject1.Models
{
    public class CustomerLogin
    {
        [Key]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]
        [Display(Name = "Email ID")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
