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
                .WithMessage(DomainEntitiesValidationMessages.SectionValidator_Name_Required)
                .MaximumLength(FieldRules.NameMaxLength)
                .WithMessage(string.Format(DomainEntitiesValidationMessages.SectionValidator_Name_MaxLength, FieldRules.NameMaxLength));

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage(DomainEntitiesValidationMessages.SectionValidator_Content_Required);

            RuleFor(x => x.IsIndividual)
                .NotEmpty()
                .WithMessage(DomainEntitiesValidationMessages.SectionValidator_IsIndividual_Required);
        }
    }
}
