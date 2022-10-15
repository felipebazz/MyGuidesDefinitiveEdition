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
                .WithMessage("cadastrar")
                .MaximumLength(FieldRules.NameMaxLength)
                .WithMessage("cadastrar");

            RuleFor(x => x.Hidden)
                .NotEmpty()
                .WithMessage("cadastrar");
        }
    }
}
