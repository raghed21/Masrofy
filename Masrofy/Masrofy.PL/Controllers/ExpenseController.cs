using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using Masrofy.DAL.Extends;
using Masrofy.DAL.Database;
using Masrofy.BLL.Models;
using Masrofy.DAL.Entities;
using Masrofy.BLL.Interfaces;
using AutoMapper;

namespace Masrofy.PL.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly MasrofyContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPlan plan;
        private readonly IExpense expense;
        private readonly IMapper mapper;


        public ExpenseController(MasrofyContext context, UserManager<ApplicationUser> userManager, IPlan plan, IExpense expense, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            this.plan = plan;
            this.expense = expense;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
                return Unauthorized();

          ViewBag.DepList =  new SelectList(Enum.GetValues(typeof(ExpenseType)).Cast<ExpenseType>()
                .Select(e => new { Id = (int)e, Name = e.ToString() }), "Id", "Name");
            return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(ExpenseVM newExpense)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
                return Unauthorized();

            var expenseEntity = new Expense
            {
                Amount = newExpense.Amount,
                Type = newExpense.Type,
                Date = DateTime.Now,
                ApplicationUserId = userId
            };

            await expense.AddExpense(expenseEntity);

            var UserPlan = await plan.GetPlanAsyncByUserId(userId);
            
            plan.Clac(UserPlan, expenseEntity);

            //return RedirectToAction("Index", "Plan");
            return RedirectToAction("ViewExpense");
        }

        public async Task<IActionResult> ViewExpense()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
                return Unauthorized();

           var expenses = await expense.GetAllExpensesByUserId(userId);

           var expensesVM = mapper.Map<IEnumerable<ExpenseVM>>(expenses);

            return View(expensesVM);
        }


    }
}