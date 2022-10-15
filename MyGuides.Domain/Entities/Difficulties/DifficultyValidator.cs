using FluentValidation;
using MyGuides.Domain.Constants;

namespace MyGuides.Domain.Entities.Difficulties
{
    public class DifficultyValidator : AbstractValidator<Difficulty>
    {
        public DifficultyValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("cadastrar")
                .MaximumLength(FieldRules.NameMaxLength)
                .WithMessage("cadastrar");

            RuleFor(x => x.Image)
                .NotEmpty()
                .WithMessage("cadastrar")
                .MaximumLength(FieldRules.TextFieldMaxLength)
                .WithMessage("cadastrar");

            RuleFor(x => x.Order)
                .NotEmpty()
                .WithMessage("cadastrar");
        }
    }
}
