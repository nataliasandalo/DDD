using Application.User.DTO;
using FluentValidation;

namespace Application.User.Validator
{
    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name cannot be null");
        }
    }
}
