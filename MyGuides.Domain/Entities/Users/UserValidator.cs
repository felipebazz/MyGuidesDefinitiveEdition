using FluentValidation;
using MyGuides.Domain.Constants;
using System.Net.Mail;

namespace MyGuides.Domain.Entities.Users;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.UserName)
               .NotEmpty()
               .WithMessage(DomainEntitiesValidationMessages.UserValidator_Username_Required)
               .MaximumLength(FieldRules.NameMaxLength)
               .WithMessage(string.Format(DomainEntitiesValidationMessages.DifficultyValidator_Name_MaxLength, FieldRules.NameMaxLength));

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(DomainEntitiesValidationMessages.DifficultyValidator_Image_Required)
            .MaximumLength(FieldRules.TextFieldMaxLength)
            .WithMessage(string.Format(DomainEntitiesValidationMessages.DifficultyValidator_Image_MaxLength, FieldRules.TextFieldMaxLength));

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(DomainEntitiesValidationMessages.UserValidator_Email_Required)
            .Custom((x, y) => {
                if (!MailAddress.TryCreate(x, out _))
                    y.AddFailure(DomainEntitiesValidationMessages.UserValidator_Email_Invalid);
            });
    }
}
