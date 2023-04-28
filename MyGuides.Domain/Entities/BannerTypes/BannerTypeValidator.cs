using FluentValidation;
using MyGuides.Domain.Constants;

namespace MyGuides.Domain.Entities.BannerTypes
{
    public class BannerTypeValidator<TBannerType> : AbstractValidator<TBannerType>
        where TBannerType : BannerType
    {
        public BannerTypeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(DomainEntitiesValidationMessages.BannerTypeValidator_Name_Required)
                .MaximumLength(FieldRules.NameMaxLength)
                .WithMessage(string.Format(DomainEntitiesValidationMessages.BannerTypeValidator_Name_MaxLength, FieldRules.NameMaxLength));

            RuleFor(x => x.Hidden)
                .NotEmpty()
                .WithMessage(DomainEntitiesValidationMessages.BannerTypeValidator_Hidden_Required);
        }
    }
}
