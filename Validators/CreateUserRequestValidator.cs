using FluentValidation;
using UrlShortner.Application.Dtos.User;

namespace UrlShortner.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            string specialCharacteres = "!@#$%&*";

            RuleFor(request => request.Name)
                .NotEmpty().WithMessage("Username cannot be empty.")
                .Must(name => !name.Any(character => specialCharacteres.Contains(character))).WithMessage("Username cannot contains a special character.");

            RuleFor(request => request.Email)
                .NotEmpty().WithMessage("Email adress cannot be empty.")
                .EmailAddress().WithMessage("Received email adress is not valid.");
            RuleFor(request => request.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(8).WithMessage("Password must contain atleast 8 characteres.")
                .Must(password => password.Any(char.IsUpper)).WithMessage("Password must contains an upper character")
                .Must(password => password.Any(char.IsDigit)).WithMessage("Password must contains atleast one number.")
                .Must(password => password.Any(character => specialCharacteres.Contains(character))).WithMessage("Password must contains a special character.");
        }
    }
}
