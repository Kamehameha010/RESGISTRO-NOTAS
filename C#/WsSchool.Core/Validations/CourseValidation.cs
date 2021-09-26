using FluentValidation;
using WsSchool.Core.Models.DTOs;

namespace WsSchool.Core.Validations
{
    public class CourseValidation : AbstractValidator<CourseDTO>
    {
        public CourseValidation()
        {
            RuleFor(course => course.Code).NotNull().MaximumLength(20);
            RuleFor(course => course.Name).MaximumLength(45);
        }
    }
}
