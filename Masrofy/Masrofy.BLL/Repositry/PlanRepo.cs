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
      private readonly   MasrofyContext db ;
       
        public PlanRepo(MasrofyContext db)
        {
            this.db = db;
        }
        public async Task GeneratePlanAsync(decimal income, string userId)
        {
            var userPlan = db.Plans
                .Where(p => p.IdentityUserId == userId)
                .OrderByDescending(p => p.Id)
                .FirstOrDefault();

            if (userPlan == null && income>0)
            {
               
                    Plan p = new Plan();
                    decimal rest;
                    decimal Eaccount;//لكل حساب كم ياخذ
                    p.Charity = income * 0.01m; //m at the end to treate it as decimal
                rest = income - p.Charity;//rest=99
                    Eaccount = rest / 3;//eaccount=33
                    p.PersonalAccount = Eaccount;
                    p.Obligation = Eaccount;
                    p.SavingAmount = Eaccount;
                    p.Income = income;//100
                    p.IdentityUserId = userId;
                    await db.Plans.AddAsync(p);
            } else
            {
                if (income > 0) { 
                    userPlan.Income = userPlan.Income + income;//110
                    userPlan.Charity = (income * 0.01m) + userPlan.Charity;//1.1
                    decimal rest = userPlan.Income - userPlan.Charity;//108.9
                    decimal Eaccount = rest / 3;//36.3
                    userPlan.PersonalAccount = Eaccount;
                    userPlan.Obligation = Eaccount;
                    userPlan.SavingAmount = Eaccount;
                    db.Plans.Update(userPlan);
                }

            }

                await db.SaveChangesAsync();
        }


        //Step1
        public async Task<Plan> GetPlanAsyncByUserId(string userId)
        {
            return  db.Plans
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
                    if(model.Amount>0 && model.Amount<= UserPlan.PersonalAccount)
                        UserPlan.PersonalAccount -= model.Amount;
                         break;
                case ExpenseType.Saving_amount:
                    if(model.Amount>0 && model.Amount <= UserPlan.SavingAmount)
                     UserPlan.SavingAmount -= model.Amount; 
                    break;

                case ExpenseType.Pay_off_a_debt:
                    if (model.Amount > 0 && model.Amount <= UserPlan.Obligation)
                        UserPlan.Obligation -= model.Amount;
                    break;
            }
           db.Plans.Update(UserPlan);
           await db.SaveChangesAsync();
        }

    }
}