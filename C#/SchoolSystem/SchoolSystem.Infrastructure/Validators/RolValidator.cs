using FluentValidation;
using SchoolSystem.Core.DTOs;

namespace SchoolSystem.Infrastructure.Validators
{
    public class RolValidator : AbstractValidator<RolDTO>
    {
        public RolValidator() => RuleFor(rol => rol.Name).NotNull();
    }
}