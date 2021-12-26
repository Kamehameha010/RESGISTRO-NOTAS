using FluentValidation;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Infrastructure.Validators
{
    public class UserLoginValidator : AbstractValidator<UserLogin>
    {
        public UserLoginValidator()
        {
            RuleFor(user => user.Username).NotNull();
            RuleFor(user => user.Password).NotNull();
        }
    }
}