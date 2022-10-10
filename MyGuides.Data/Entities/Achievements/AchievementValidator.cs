using FluentValidation;
using MyGuides.Domain.Constants;

namespace MyGuides.Domain.Entities.Achievements
{
    public class AchievementValidator : AbstractValidator<Achievement>
    {
        public AchievementValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("adicionar mensagens no projeto")
                .MaximumLength(FieldRules.NameMaxLength)
                .WithMessage("adicionar mensagens no projeto");

            RuleFor(x => x.DisplayName)
                .NotEmpty()
                .WithMessage("adicionar mensagens no projeto")
                .MaximumLength(FieldRules.NameMaxLength)
                .WithMessage("adicionar mensagens no projeto");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("adicionar mensagens no projeto")
                .MaximumLength(FieldRules.TextFieldMaxLength)
                .WithMessage("adicionar mensagens no projeto");

            RuleFor(x => x.Hidden)
                .NotEmpty()
                .WithMessage("adicionar mensagens no projeto");

            RuleFor(x => x.IconGray)
                .NotEmpty()
                .WithMessage("adicionar mensagens no projeto")
                .MaximumLength(FieldRules.TextFieldMaxLength)
                .WithMessage("adicionar mensagens no projeto");

            RuleFor(x => x.Icon)
                .NotEmpty()
                .WithMessage("adicionar mensagens no projeto")
                .MaximumLength(FieldRules.TextFieldMaxLength)
                .WithMessage("adicionar mensagens no projeto");

            RuleFor(x => x.GameId)
                .NotEmpty()
                .WithMessage("cadastrar");
        }
    }
}
