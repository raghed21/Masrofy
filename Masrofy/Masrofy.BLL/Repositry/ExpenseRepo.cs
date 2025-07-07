using Masrofy.BLL.Interfaces;
using Masrofy.DAL.Database;
using Masrofy.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masrofy.BLL.Repositry
{
    public class ExpenseRepo:IExpense
    {


        private readonly MyContext db;

        public ExpenseRepo(MyContext db)
        {
            this.db = db;
        }
        public async Task AddExpense(Expense e)
        {
            db.Expenses.Add(e);
            db.SaveChanges();
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesByUserId(string userId)
        {
           return await db.Expenses.Where(a=>a.ApplicationUserId==userId).ToListAsync();
        }

    }
}
