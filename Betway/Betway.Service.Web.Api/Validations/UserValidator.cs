using Betway.Service.Web.Api.DTO;
using FluentValidation;

namespace Betway.Service.Web.Api.Validations
{
    public class UserValidator : AbstractValidator<UserRequest>
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Methods
        #endregion

        #region Constructors
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email address is required")
                .NotEmpty().WithMessage("Email address is required").
                 Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
                 .WithMessage("A valid email is required");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Your password length must be at least 8.");
        }
        #endregion
    }
}
