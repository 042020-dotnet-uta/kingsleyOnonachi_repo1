using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proj1.BusinessLogic
{
    public enum CustomerSearchType
    {
        [Description("First Name")]
        [Display(Name = "First Name")]
        FirstName,
        [Description("Last Name")]
        [Display(Name = "Last Name")]
        LastName,
        [Description("Email Address")]
        [Display(Name = "Email Address")]
        Email
    }
}
