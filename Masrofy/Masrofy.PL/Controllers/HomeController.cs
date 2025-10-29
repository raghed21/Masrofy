using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Masrofy.PL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
            //return Content("صفحة Index وصلت لها بنجاح");
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}
