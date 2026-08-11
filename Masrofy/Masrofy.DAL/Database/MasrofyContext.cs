using Masrofy.DAL.Entities;
using Masrofy.DAL.Extends;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masrofy.DAL.Database
{
    public class MasrofyContext : IdentityDbContext<ApplicationUser>
    {
        public MasrofyContext(DbContextOptions<MasrofyContext> opt) : base(opt)
        {
        }

        public DbSet<Plan> Plans { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<SavingGoal> SavingGoals { get; set; }

    }
}
