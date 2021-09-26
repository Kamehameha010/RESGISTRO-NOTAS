using FluentValidation;
using WsSchool.Core.Models.DTOs;

namespace WsSchool.Core.Validations
{
    public class AccessValidation : AbstractValidator<CourseDTO>
    {
        public AccessValidation()
        {
            RuleFor(access => access.Code).NotEmpty();
            RuleFor(access => access.Name).NotEmpty();
        }
    }
}
