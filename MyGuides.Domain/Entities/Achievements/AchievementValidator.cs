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
                .WithMessage("name")
                .MaximumLength(FieldRules.NameMaxLength)
                .WithMessage("name");

            RuleFor(x => x.DisplayName)
                .NotEmpty()
                .WithMessage("displayname")
                .MaximumLength(FieldRules.NameMaxLength)
                .WithMessage("displayname");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description")
                .MaximumLength(FieldRules.TextFieldMaxLength)
                .WithMessage("Description");

            RuleFor(x => x.Hidden)
                .NotNull()
                .WithMessage("Hidden");

            RuleFor(x => x.IconGray)
                .NotEmpty()
                .WithMessage("IconGray")
                .MaximumLength(FieldRules.TextFieldMaxLength)
                .WithMessage("IconGray");

            RuleFor(x => x.Icon)
                .NotEmpty()
                .WithMessage("Icon")
                .MaximumLength(FieldRules.TextFieldMaxLength)
                .WithMessage("Icon");

            RuleFor(x => x.GameId)
                .NotEmpty()
                .WithMessage("GameId");
        }
    }
}
