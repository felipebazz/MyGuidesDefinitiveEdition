using FluentValidation;
using MyGuides.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
