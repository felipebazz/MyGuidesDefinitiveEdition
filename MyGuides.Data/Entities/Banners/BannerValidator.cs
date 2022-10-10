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
            RuleFor(x => x.ImageName)
                .NotEmpty()
                .WithMessage("cadastrar")
                .MaximumLength(FieldRules.TextFieldMaxLength);

            RuleFor(x => x.ImageId)
                .NotEmpty()
                .WithMessage("cadastrar")
                .MaximumLength(FieldRules.TextFieldMaxLength)
                .WithMessage("cadastrar");

            RuleFor(x => x.ImageURL)
                .NotEmpty()
                .WithMessage("cadastrar")
                .MaximumLength(FieldRules.TextFieldMaxLength)
                .WithMessage("cadastrar");

            RuleFor(x => x.BannerTypeId)
                .NotEmpty()
                .WithMessage("cadastrar");

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
