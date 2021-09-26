using FluentValidation;
using WsSchool.Core.Models.DTOs;

namespace WsSchool.Core.Validations
{
    public class StudentValidation : AbstractValidator<StudentDTO>
    {
        public StudentValidation()
        {
            RuleFor(student => student.Classroom).NotNull().MaximumLength(45);
        }
    }
}