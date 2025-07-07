using Masrofy.BLL.Models;
using Masrofy.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masrofy.BLL.Interfaces
{
    public interface IPlan
    {
        Task GeneratePlanAsync(double income, string userId);
        public Task<Plan> GetPlanAsyncByUserId(string userId);
        public  Task Clac(Plan UserPlan, Expense model);
    }
}
