using Application.User.DTO;
using FluentValidation;

namespace Application.User.Validator
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name cannot be null");
        }
    }
}
