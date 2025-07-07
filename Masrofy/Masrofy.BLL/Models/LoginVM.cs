using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masrofy.BLL.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Email Invalid")]
        public String Email { get; set; }


        [Required(ErrorMessage = "Password Required")]
        [MinLength(5, ErrorMessage = "Min length is 5")]
        //[Compare("Password", ErrorMessage="Password not match")]
        public String Password { get; set; }

        public bool RememberMe { get; set; } 

    }
}
