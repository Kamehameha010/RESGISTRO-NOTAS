using FluentValidation;
using WsSchool.Core.Models.DTOs;

namespace WsSchool.Core.Validations
{
    public class PersonValidation : AbstractValidator<PersonDTO>
    {
        public PersonValidation()
        {
            RuleFor(person => person.Name).NotNull().MaximumLength(45);
            RuleFor(person => person.Nid).NotNull();
            RuleFor(person => person.Address).NotEmpty().MaximumLength(45);
            RuleFor(person => person.PhoneNumber).NotEmpty().MaximumLength(12);
        }

    }
}