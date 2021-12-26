using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.UI.Controllers
{
    public class UserController : Controller
    {
        public ViewResult Register()
        {
            return View();
        }
    }
}