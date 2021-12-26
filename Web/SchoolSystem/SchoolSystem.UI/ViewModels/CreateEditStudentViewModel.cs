using SchoolSystem.Core.DTOs;

namespace SchoolSystem.UI.ViewModels
{
    public class CreateEditStudentViewModel
    {
        public UserDTO Student { get; set; }
        public StudentDTO StudentDetail { get; set; }
    }
}