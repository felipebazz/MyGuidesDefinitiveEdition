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
                .WithMessage("cadastrar")
                .MaximumLength(FieldRules.NameMaxLength)
                .WithMessage("cadastrar");

            RuleFor(x => x.Version)
                .NotEmpty()
                .WithMessage("cadastrar");

            RuleFor(x => x.AppId)
                .NotEmpty()
                .WithMessage("cadastrar");

            RuleFor(x => x.Achievements)
                .ForEach(x => x.SetInheritanceValidator(v =>
                {
                    v.Add(new AchievementValidator());
                }))
                .When(x => x.Achievements is not null);
        }
    }
}
