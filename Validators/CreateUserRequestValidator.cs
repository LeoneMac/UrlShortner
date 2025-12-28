using FluentValidation;
using UrlShortner.Application.Dtos.User;

namespace UrlShortner.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty().WithMessage("Username cannot be empty.");

            RuleFor(request => request.Email)
                .NotEmpty().WithMessage("Email adress cannot be empty.")
                .EmailAddress().WithMessage("Received email adress is not valid.");

            RuleFor(request => request.Password)
                .NotEmpty().WithMessage("Password cannot be empty.");
        }
    }
}
