using FluentValidation;
using MyGuides.Domain.Constants;
using MyGuides.Domain.Entities.BannerTypes;
using MyGuides.Domain.Entities.BannerTypes.Types;

namespace MyGuides.Domain.Entities.Banners
{
    public class BannerValidator : AbstractValidator<Banner>
    {
        public BannerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(DomainEntitiesValidationMessages.BannerValidator_Name_Required)
                .MaximumLength(FieldRules.NameMaxLength)
                .WithMessage(string.Format(DomainEntitiesValidationMessages.BannerValidator_Name_MaxLength, FieldRules.NameMaxLength));

            RuleFor(x => x.ImageId)
                .NotEmpty()
                .WithMessage(DomainEntitiesValidationMessages.BannerValidator_ImageId_Required)
                .MaximumLength(FieldRules.TextFieldMaxLength)
                .WithMessage(string.Format(DomainEntitiesValidationMessages.BannerValidator_ImageId_MaxLength, FieldRules.TextFieldMaxLength));

            RuleFor(x => x.Url)
                .NotEmpty()
                .WithMessage(DomainEntitiesValidationMessages.BannerValidator_Url_Required)
                .MaximumLength(FieldRules.TextFieldMaxLength)
                .WithMessage(string.Format(DomainEntitiesValidationMessages.BannerValidator_Url_MaxLength, FieldRules.TextFieldMaxLength));

            RuleFor(x => x.BannerTypeId)
                .NotEmpty()
                .WithMessage(DomainEntitiesValidationMessages.BannerValidator_BannerTypeId_Required);

            RuleFor(x => x.BannerType)
                .SetInheritanceValidator(v =>
                {
                    v.Add(new BannerTypeValidator<Divisor>());
                    v.Add(new BannerTypeValidator<Header>());
                })
                .When(x => x.BannerType is not null);
        }
    }
}
