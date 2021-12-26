using SchoolSystem.Core.DTOs;

namespace SchoolSystem.UI.ViewModels
{
    public class CreateEditTeacherViewModel
    {
        public UserDTO Teacher { get; set; }
        public TeacherDTO TeacherDetail { get; set; }
    }
}