using Masrofy.BLL.Models;
using Masrofy.DAL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masrofy.BLL.Interfaces
{
    public interface IExpense
    {
        public Task AddExpense(Expense newExpense);
        public Task<IEnumerable<Expense>> GetAllExpensesByUserId(string userId);
    }
}
