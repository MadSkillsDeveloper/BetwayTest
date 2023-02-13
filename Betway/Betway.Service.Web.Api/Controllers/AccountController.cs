using Betway.Service.Web.Api.DTO;
using Betway.Service.Web.Api.Helpers;
using Betway.Service.Web.Api.Services;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Betway.Service.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IValidator<UserRequest> _userValidator;
        #endregion

        #region Properties
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> UserLogin([FromBody] UserRequest request)
        {
            ValidationResult validationResult = _userValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult
                    .Errors
                    .Select(x => new
                    {
                        property = x.PropertyName.ToLower() == "email" ? "username" : x.PropertyName.ToLower(),
                        message = x.ErrorMessage
                    })
                    .ToList();

                return BadRequest(errors);
            }
            var isLoggedIn = await _userService.Login(request);

            if (!isLoggedIn)
                return StatusCode(StatusCodes.Status403Forbidden, "Incorrect username or password.");

            return Ok(new SingleResult<bool>("Logged in successfully", isLoggedIn));
        }
        #endregion

        #region Constructors
        public AccountController(
            IUserService userService,
            IValidator<UserRequest> userValidator)
        {
            _userService = userService;
            _userValidator = userValidator;
        }
        #endregion

    }
}
