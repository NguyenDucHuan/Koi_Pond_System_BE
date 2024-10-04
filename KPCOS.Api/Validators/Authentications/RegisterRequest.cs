using FluentValidation;
using KPOCOS.Domain.DTOs.Resquest;
using KPCOS.Api.Enums;

namespace KPCOS.Api.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterDto>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.registerAccount.UserName)
                .NotEmpty().WithMessage("Tài khoản không được để trống.")
                .Length(3, 50).WithMessage("Tài khoản phải có độ dài từ 3 đến 50 ký tự.");

            RuleFor(x => x.registerAccount.Password)
                .NotEmpty().WithMessage("Mật khẩu không được để trống.");
            // .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            // .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
            // .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
            // .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.")
            // .Matches(@"[\!\?\*\.]+").WithMessage("Password must contain at least one (!? *.).");

            RuleFor(x => x.registerAccount.ConfirmPassword)
                .NotEmpty().WithMessage("Mật khẩu không khớp.")
                .Equal(x => x.registerAccount.Password).WithMessage("Mật khẩu không khớp.");

            RuleFor(x => x.registerUserProfile.LastName)
                .NotEmpty().WithMessage("Họ không được để trống.")
                .MaximumLength(100).WithMessage("Họ không được quá 100 ký tự.");

            RuleFor(x => x.registerUserProfile.FirstName)
                .NotEmpty().WithMessage("Tên không được để trống.")
                .MaximumLength(100).WithMessage("Tên không được quá 100 ký tự.");

            RuleFor(x => x.registerUserProfile.Phone)
                .NotEmpty().WithMessage("Số điện thoại không được để trống.")
                .Matches(@"^0\d{9}$").WithMessage("Số điện thoại không đúng định dạng. Phải là 10 số và bắt đầu bằng 0.");

            RuleFor(x => x.registerUserProfile.Birthday)
                .NotEmpty().WithMessage("Ngày sinh không được để trống.")
                .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Ngày sinh không được trong tương lai.");

            RuleFor(x => x.registerUserProfile.Gender)
                .NotEmpty().WithMessage("Giới tính không được để trống.")
                .IsEnumName(typeof(Gender), caseSensitive: false).WithMessage("Giới tính không đúng định dạng.");

            RuleFor(x => x.registerUserProfile.Email)
                .NotEmpty().WithMessage("Email không được để trống.")
                .EmailAddress().WithMessage("Email không đúng định dạng.");
        }
    }
}