
using FluentValidation;
using WsSchool.Core.Models.DTOs;

namespace WsSchool.Core.Validations
{
    public class LoginValidation : AbstractValidator<UserDTO>
    {
        public LoginValidation()
        {
            RuleFor(login => login.Username).NotNull().MaximumLength(45);
            RuleFor(login => login.Password).NotNull();
            RuleFor(login => login.RolId).NotNull();
        }

    }
}