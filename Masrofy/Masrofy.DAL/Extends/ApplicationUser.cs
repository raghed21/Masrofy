using Masrofy.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masrofy.DAL.Extends
{
    public class ApplicationUser:IdentityUser
    {
        public bool IsAgree {  get; set; }
        //------------------------------------------------------------------------------
        public virtual List<Plan> Plans { get; set; } //Navigation property for Plan
        public virtual List<Expense> Expenses { get; set; } = new();  // قائمة المصروفات 
    }
}
