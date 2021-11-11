using FluentValidation;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Infrastructure.Validators
{
    public class UserLoginValidator : AbstractValidator<userLogin>
    {
        public UserLoginValidator()
        {
            RuleFor(user => user.Username).NotNull();
            RuleFor(user => user.Password).NotNull();
        }
    }
}