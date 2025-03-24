using FluentValidation;
using UserApi.Application.DTOs;

namespace UserApi.Application.Validators
{

    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("Le prénom est requis.")
                .MinimumLength(3).WithMessage("Le prénom doit contenir au moins 3 caractères.");

            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("Le nom est requis.")
                .MinimumLength(3).WithMessage("Le nom doit contenir au moins 3 caractères.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("L'email est requis.")
                .EmailAddress().WithMessage("L'email n'est pas valide.");
        }
    }
}
