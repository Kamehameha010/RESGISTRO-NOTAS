using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}