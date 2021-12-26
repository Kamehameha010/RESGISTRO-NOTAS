using Microsoft.AspNetCore.Mvc;
using SchoolSystem.UI.ViewModels;

namespace SchoolSystem.UI.Controllers
{
    public class StudentController : Controller
    {
        public ViewResult Index() => View();

        public ViewResult Create()
        {
            return View("~/Views/Student/CreateEdit.cshtml", new CreateEditStudentViewModel());
        }

        [HttpPost]
        public IActionResult Create(CreateEditStudentViewModel model)
        {
            return null;
        }
        public ViewResult Edit(int? id)
        {
            if (id != null)
            {
                var d = "ds";
            }
            return View("~/Views/Student/CreateEdit.cshtml", new CreateEditStudentViewModel());
        }

        [HttpPost]
        public IActionResult Edit(CreateEditStudentViewModel model)
        {
            return null;
        }
    }
}