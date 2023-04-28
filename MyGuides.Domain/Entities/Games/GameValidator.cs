using FluentValidation;
using MyGuides.Domain.Constants;
using MyGuides.Domain.Entities.Achievements;

namespace MyGuides.Domain.Entities.Games
{
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(DomainEntitiesValidationMessages.GameValidator_Name_Required)
                .MaximumLength(FieldRules.NameMaxLength)
                .WithMessage(string.Format(DomainEntitiesValidationMessages.GameValidator_Name_MaxLength, FieldRules.NameMaxLength));

            RuleFor(x => x.Version)
                .NotEmpty()
                .WithMessage(DomainEntitiesValidationMessages.GameValidator_Version_Required);

            RuleFor(x => x.AppId)
                .NotEmpty()
                .WithMessage(DomainEntitiesValidationMessages.GameValidator_AppId_Required);

            RuleFor(x => x.Achievements)
                .ForEach(x => x.SetInheritanceValidator(v =>
                {
                    v.Add(new AchievementValidator());
                }))
                .When(x => x.Achievements is not null);
        }
    }
}
