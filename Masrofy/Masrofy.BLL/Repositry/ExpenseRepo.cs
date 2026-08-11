using Masrofy.BLL.Interfaces;
using Masrofy.BLL.Models;
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


        private readonly MasrofyContext db;

        public ExpenseRepo(MasrofyContext db)
        {
            this.db = db;
        }
        public async Task AddExpense(Expense e)
        {
            if(e.Amount>0)
            {
                db.Expenses.Add(e);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesByUserId(string userId)
        {
           return await db.Expenses.Where(a=>a.ApplicationUserId==userId).ToListAsync();
        }

    }
}
