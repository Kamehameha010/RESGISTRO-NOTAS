using FluentValidation;
using SchoolSystem.Core.DTOs;

namespace SchoolSystem.Infrastructure.Validators
{
    public class CourseValidator : AbstractValidator<CourseDTO>
    {
        public CourseValidator()
        {
            RuleFor(course => course.Code)
            .NotNull()
            .MaximumLength(10);

            RuleFor(course => course.CourseStatusId)
            .NotNull();
        }
    }
}