using FluentValidation;
using MyGuides.Domain.Constants;

namespace MyGuides.Domain.Entities.Sections
{
    public class SectionValidator : AbstractValidator<Section>
    {
        public SectionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("cadastrar")
                .MaximumLength(FieldRules.NameMaxLength)
                .WithMessage("cadastrar");

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("cadastrar");

            RuleFor(x => x.IsIndividual)
                .NotEmpty()
                .WithMessage("cadastrar");
        }
    }
}
