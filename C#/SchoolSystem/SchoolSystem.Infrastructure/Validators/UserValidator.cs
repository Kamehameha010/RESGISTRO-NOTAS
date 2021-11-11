using FluentValidation;
using SchoolSystem.Core.DTOs;

namespace SchoolSystem.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotNull()
                .MaximumLength(45);

            RuleFor(user => user.Nid)
                .NotNull();

            RuleFor(user => user.Address)
                .NotNull()
                .MaximumLength(80);

            RuleFor(user => user.Phone)
                .NotNull()
                .MaximumLength(80);

            RuleFor(user => user.Username)
                .NotNull()
                .MaximumLength(10);

            RuleFor(user => user.Password)
                .NotNull()
                .MaximumLength(45);

            RuleFor(user => user.RolId)
                .NotNull();
        }
    }
}