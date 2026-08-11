using Masrofy.DAL.Extends;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masrofy.DAL.Entities
{
    public class Plan
    {
        public Plan() {
            Month = DateTime.Now; // Initialize Month to current date

        }
        public int Id { get; set; } //PK 
        public decimal Income { get; set; }
        public decimal Charity { get; set; } //حساب صدقة
        public decimal SavingAmount { get; set; }
        public decimal PersonalAccount { get; set; } //حساب شخصي 

        public decimal Obligation { get; set; } //التزامات
        public DateTime Month { get; set; }
        public string IdentityUserId { get; set; } //FK


        //------------------------------------------------------
        public ApplicationUser IdentityUser { get; set; }//NP

        
    }
}
