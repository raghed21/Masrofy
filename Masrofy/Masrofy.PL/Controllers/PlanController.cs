using Masrofy.BLL.Interfaces;
using Masrofy.BLL.Models;
using Masrofy.BLL.Repositry;
using Masrofy.DAL.Extends;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Masrofy.PL.Controllers
{
    [Authorize]
    public class PlanController : Controller
    {
        //Design pattren(Dependency Injection)
       private readonly IPlan plan;
        //private readonly IUserProfile user;
        private readonly UserManager<ApplicationUser> userManager;



        public PlanController(IPlan plan, UserManager<ApplicationUser> userManager )
        {
            this.plan = plan;
            //this.user = user;
            this.userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var userId = userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var Mplan = await plan.GetPlanAsyncByUserId(userId);
                if (Mplan != null)
                {
                    PlanVM planVM = new PlanVM
                    {
                        Income = Mplan.Income,
                        Charity = Mplan.Charity,
                        PersonalAccount = Mplan.PersonalAccount,
                        Obligation = Mplan.Obligation,
                        SavingAmount = Mplan.SavingAmount
                    };
                    return View(planVM);
                }
            }         
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Index(PlanVM a)
        {
            string userId = userManager.GetUserId(User);
            if (userId != null)
            {
                await plan.GeneratePlanAsync(a.Income, userId);

            }
            return RedirectToAction("Index");
        }

    }
}
