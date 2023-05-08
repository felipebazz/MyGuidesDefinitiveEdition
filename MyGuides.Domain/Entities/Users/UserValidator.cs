using FluentValidation;
using MyGuides.Domain.Constants;

namespace MyGuides.Domain.Entities.Users;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage(DomainEntitiesValidationMessages.DifficultyValidator_Name_Required)
               .MaximumLength(FieldRules.NameMaxLength)
               .WithMessage(string.Format(DomainEntitiesValidationMessages.DifficultyValidator_Name_MaxLength, FieldRules.NameMaxLength));

        RuleFor(x => x.Image)
            .NotEmpty()
            .WithMessage(DomainEntitiesValidationMessages.DifficultyValidator_Image_Required)
            .MaximumLength(FieldRules.TextFieldMaxLength)
            .WithMessage(string.Format(DomainEntitiesValidationMessages.DifficultyValidator_Image_MaxLength, FieldRules.TextFieldMaxLength));

        RuleFor(x => x.Order)
            .NotEmpty()
            .WithMessage(DomainEntitiesValidationMessages.DifficultyValidator_Order_Required);
    }
}
