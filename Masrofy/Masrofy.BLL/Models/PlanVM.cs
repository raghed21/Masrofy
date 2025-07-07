using Masrofy.DAL.Extends;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masrofy.BLL.Models
{
    public class PlanVM
    {
     
        public int Id { get; set; } //PK 
        public double Income { get; set; }
        public double Charity { get; set; } //حساب صدقة
        public double SavingAmount { get; set; }
        public double PersonalAccount { get; set; } //حساب شخصي 
        public double Obligation { get; set; } //التزامات
        public DateTime Month { get; set; }
        public string IdentityUserId { get; set; } //FK

        //------------------------------------------------------
        //public int UserProfileId { get; set; } //FK

        public ApplicationUser IdentityUser { get; set; }


    }
}
