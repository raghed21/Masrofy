using Masrofy.DAL.Extends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.Rendering;


namespace Masrofy.DAL.Entities
{
    public enum ExpenseType
    {
        Food,
        Clothes,
        Communications,
        Entertainment,
        Saving_amount,
        Pay_off_a_debt,

    }

    public class Expense
    {
        public int Id { get; set; }
        //public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public ExpenseType Type { get; set; } //Enum for type of expense
        public string ApplicationUserId { get; set; }//FK
        //--------------------------------------------------------------------
        public ApplicationUser ApplicationUser { get; set; } //NP


    }
}
