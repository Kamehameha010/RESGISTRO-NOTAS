using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.UI.Controllers
{
    public class LoginController : Controller
    {
        public ViewResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLogin model)
        {
            return RedirectPermanent("/Home/");
        }

        public async Task<IActionResult> SignOut(UserLogin model)
        {
            return View(nameof(SignIn));
        }

    }
}