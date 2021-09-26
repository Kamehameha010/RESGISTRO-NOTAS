using FluentValidation;
using WsSchool.Core.Models.DTOs;

namespace WsSchool.Core.Validations
{
    public class GradeBookValidation : AbstractValidator<GradeBookDTO>
    {
        public GradeBookValidation()
        {
            RuleFor(grade => grade.Q1).NotNull();
            RuleFor(grade => grade.Q2).NotNull();
            RuleFor(grade => grade.Q3).NotNull();
        }

    }
}