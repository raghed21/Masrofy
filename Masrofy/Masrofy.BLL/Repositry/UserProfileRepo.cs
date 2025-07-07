using Masrofy.BLL.Models;
using Masrofy.DAL.Database;
using Masrofy.DAL.Entities;
using Masrofy.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masrofy.BLL.Repositry
{
    //public class UserProfileRepo : IUserProfile
    //{
    //    private readonly MyContext db;

    //    public UserProfileRepo(MyContext db)
    //    {
    //        this.db = db;
    //    }
    //    public async Task AddUser(UserProfileVM obj)
    //    {
    //        //PL==> DAL

    //        UserProfile p = new UserProfile();
    //        p.Name = obj.Name;
    //        p.Email= obj.Email;

    //        await db.UserProfiles.AddAsync(p); //add object in Database
    //        await db.SaveChangesAsync();
    //    }

    //    public async Task AddIncome(PlanVM obj)
    //    {
    //        //PL==> DAL

    //        Plan p = new Plan();
    //        p.Income = obj.Income;
    //        await db.Plans.AddAsync(p); //add object in Database
    //        await db.SaveChangesAsync();

    //    }
    //}
}
