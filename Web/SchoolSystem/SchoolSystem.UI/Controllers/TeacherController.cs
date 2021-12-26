using Microsoft.AspNetCore.Mvc;
using SchoolSystem.UI.ViewModels;

namespace SchoolSystem.UI.Controllers
{
    public class TeacherController : Controller
    {
        public ViewResult Index() => View();

        public ViewResult Create()
        {
            return View("~/Views/Student/CreateEdit.cshtml", new CreateEditTeacherViewModel());
        }

        [HttpPost]
        public IActionResult Create(CreateEditTeacherViewModel model)
        {
            return null;
        }
        public ViewResult Edit(int? id)
        {
            if (id != null)
            {
                var d = "ds";
            }
            return View("~/Views/Student/CreateEdit.cshtml", new CreateEditTeacherViewModel());
        }

        [HttpPost]
        public IActionResult Edit(CreateEditTeacherViewModel model)
        {
            return null;
        }
    }
}