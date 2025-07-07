using Masrofy.BLL.Interfaces;
using Masrofy.BLL.Models;
using Masrofy.DAL.Database;
using Masrofy.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Masrofy.BLL.Repositry
{
    public class PlanRepo : IPlan
    {
      private readonly   MyContext db ;
       
        public PlanRepo(MyContext db)
        {
            this.db = db;
        }
        public async Task GeneratePlanAsync(double income, string userId)
        {
            var userPlan = db.Plans
                .Where(p => p.IdentityUserId == userId)
                .OrderByDescending(p => p.Id)
                .FirstOrDefault();

            if (userPlan == null)
            {
                Plan p = new Plan();
                double rest;
                double Eaccount;//لكل حساب كم ياخذ
                p.Charity = income * 0.01;
                rest = income - p.Charity;
                Eaccount = rest / 3;
                p.PersonalAccount = Eaccount;
                p.Obligation = Eaccount;
                p.SavingAmount = Eaccount;
                p.Income = income;
                p.IdentityUserId = userId;
                await db.Plans.AddAsync(p);

            } else
            {
                userPlan.Income = userPlan.Income+ income;
                userPlan.Charity = (income * 0.01) + userPlan.Charity;
                double rest = userPlan.Income - userPlan.Charity;
                double Eaccount = rest / 3;
                userPlan.PersonalAccount = Eaccount;
                userPlan.Obligation = Eaccount;
                userPlan.SavingAmount = Eaccount;
                db.Plans.Update(userPlan);
            }

                await db.SaveChangesAsync();
        }


        //Step1
        public async Task<Plan> GetPlanAsyncByUserId(string userId)
        {
            return db.Plans
                .Where(p => p.IdentityUserId == userId)
                .OrderByDescending(p => p.Id)
                .FirstOrDefault();
        }

        public async Task Clac(Plan UserPlan, Expense model)
        {
            switch (model.Type)
            {
                case ExpenseType.Food:
                case ExpenseType.Clothes:
                case ExpenseType.Communications:
                case ExpenseType.Entertainment:
                    UserPlan.PersonalAccount -= model.Amount;
                    break;

                case ExpenseType.Saving_amount:
                    UserPlan.SavingAmount -= model.Amount;
                    break;

                case ExpenseType.Pay_off_a_debt:
                    UserPlan.Obligation -= model.Amount;
                    break;
            }
           db.Plans.Update(UserPlan);
           await db.SaveChangesAsync();
        }

    }
}
