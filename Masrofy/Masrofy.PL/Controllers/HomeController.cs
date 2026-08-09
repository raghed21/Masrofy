using Masrofy.DAL.Extends;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Masrofy.PL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public UserManager<ApplicationUser> userManager;
        public HomeController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            if(!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}
