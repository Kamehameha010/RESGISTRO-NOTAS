using FluentValidation;
using WsSchool.Core.Models.DTOs;

namespace WsSchool.Core.Validations
{
    public class TeacherValidation : AbstractValidator<TeacherDTO>
    {
        public TeacherValidation()
        {
            RuleFor(teacher => teacher.Subject).NotNull().MaximumLength(45);
        }

    }
}