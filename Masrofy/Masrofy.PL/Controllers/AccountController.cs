using Masrofy.BLL.Models;
using Masrofy.DAL.Extends;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Masrofy.PL.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Regestration() //sign up
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Regestration(RegestrationVM model) //sign up
        {
            try
            {
                var user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    IsAgree = model.IsAgree

                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(model);

                }
            }catch (Exception ex)
            {
                return View(model);
            }

        }
        public IActionResult Login() //sign up
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model) //sign up
        {
            try
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Account inValid");
                    }
                    return View(model);

                }
                ModelState.AddModelError("", "Account inValid");
                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }


        [HttpPost]
        public async Task <IActionResult> LogOff() 
        { 
            await signInManager.SignOutAsync();
            return RedirectToAction("Login","Account"); 
        }

        public IActionResult ForgotPassword() //sign up
        {
            return View();
        }
    }
}
