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
                .WithMessage(DomainEntitiesValidationMessages.AchievementValidator_Name_Required)
                .MaximumLength(FieldRules.NameMaxLength)
                .WithMessage(string.Format(DomainEntitiesValidationMessages.AchievementValidator_Name_MaxLength, FieldRules.NameMaxLength));

            RuleFor(x => x.Description)
                .NotNull()
                .WithMessage(DomainEntitiesValidationMessages.AchievementValidator_Description_Required)
                .MaximumLength(FieldRules.TextFieldMaxLength)
                .WithMessage(string.Format(DomainEntitiesValidationMessages.AchievementValidator_Description_MaxLength, FieldRules.TextFieldMaxLength));

            RuleFor(x => x.Hidden)
                .NotNull()
                .WithMessage(DomainEntitiesValidationMessages.AchievementValidator_Hidden_Required);

            RuleFor(x => x.IconGray)
                .NotEmpty()
                .WithMessage(DomainEntitiesValidationMessages.AchievementValidator_IconGray_Required)
                .MaximumLength(FieldRules.TextFieldMaxLength)
                .WithMessage(string.Format(DomainEntitiesValidationMessages.AchievementValidator_IconGray_MaxLength, FieldRules.TextFieldMaxLength));

            RuleFor(x => x.Icon)
                .NotEmpty()
                .WithMessage(DomainEntitiesValidationMessages.AchievementValidator_Icon_Required)
                .MaximumLength(FieldRules.TextFieldMaxLength)
                .WithMessage(string.Format(DomainEntitiesValidationMessages.AchievementValidator_Icon_MaxLength, FieldRules.TextFieldMaxLength));

            RuleFor(x => x.GameId)
                .NotEmpty()
                .WithMessage(DomainEntitiesValidationMessages.AchievementValidator_GameId_Required);
        }
    }
}
