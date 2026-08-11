using Masrofy.BLL.Models;
using Masrofy.DAL.Entities;
using Masrofy.DAL.Extends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Masrofy.BLL.Models
{
    public class ExpenseVM
    {
        public int Id { get; set; }
        //public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public ExpenseType Type { get; set; } //Enum for type of expense
        public string AccountUsed { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        //public ExpenseVM NewExpense { get; set; } = new ExpenseVM();

        //public List<Expense> ExpensesList { get; set; } = new List<Expense>();
    }
}



    