using FluentValidation;
using Market.Models.Entityes;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace Market.Validation
{
    public class UserValidator : FluentValidation.AbstractValidator<UserEntity>
    {
        public UserValidator()
        {
            RuleFor(u => u.Id).NotNull().WithMessage("Id is null");
            RuleFor(u => u.UserName).NotEmpty().MaximumLength(4).WithMessage("Incorrect UserName");
            RuleFor(u => u.Email).NotEmpty().EmailAddress().WithMessage("Incorrect Email");
            RuleFor(u => u.CreditCard).NotEmpty().CreditCard().WithMessage("Incorrect CreditCard");

            RuleFor(u => u.PhoneNumber).NotEmpty()
                .Must(x => Regex.IsMatch(x, "^\\s*\\+?\\s*([0-9][\\s-]*){9,}$")).WithMessage("Incorrect PhoneNumber");
            //https://stackoverflow.com/questions/6330399/basic-regular-expression-for-a-generic-phone-number
        }
    }
}
