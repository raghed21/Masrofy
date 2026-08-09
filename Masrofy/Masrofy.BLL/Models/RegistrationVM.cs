using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masrofy.BLL.Models
{
    public class RegistrationVM
    {
        [Required(ErrorMessage ="FullName Required")]
        public string FullName { get; set; }


        [Required(ErrorMessage="Email Required")]
        [EmailAddress(ErrorMessage="Email Invalid")]
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage ="Password Required")]
        [MinLength(5, ErrorMessage="Min length is 5")]
        //[Compare("Password", ErrorMessage="Password not match")]
        public string Password { get; set; }

        public bool IsAgree { get; set; }
    }
}
