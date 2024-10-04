using FluentValidation;
using KPOCOS.Domain.DTOs.Resquest;

namespace KPCOS.Api.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginResquest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("{PropertyName} is not null.")
                .NotEmpty().WithMessage("{PropertyName} is not empty.");
            RuleFor(x => x.Password).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("{PropertyName} is not null.")
                .NotEmpty().WithMessage("{PropertyName} is not empty.");
        }
    }
}