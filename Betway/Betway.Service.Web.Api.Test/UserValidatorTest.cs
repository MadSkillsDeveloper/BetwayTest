using Betway.Service.Web.Api.DTO;
using Betway.Service.Web.Api.Validations;
using FluentValidation.TestHelper;
using Xunit;

namespace Betway.Service.Web.Api.Test
{
    public class UserValidatorTest
    {
        #region Fields
        private readonly UserValidator _validator = new();
        #endregion

        #region Properties
        #endregion

        #region Methods
        [Fact]
        public void GivenAnInvalidEmail_ShouldHaveValidationError()
        {
            //Arrange
            var model = new UserRequest() { Email = "sdsfdsd@fdgdfd", Password = "fdsfdsdfsfsd" };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void GivenAnEmptyEmail_ShouldHaveValidationError()
        {
            //Arrange
            var model = new UserRequest() { Email = string.Empty, Password = "fdsfdsdfsfsd" };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void GivenValidEmail_ShouldNotHaveValidationError()
        {
            //Arrange
            var model = new UserRequest() { Email = "sdsfdsd@fdgdfd.com", Password = "fdsfdsdfsfsd" };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void GivenAnEmptyPassword_ShouldHaveValidationError()
        {
            //Arrange
            var model = new UserRequest() { Email = "sdsfdsd@fdgdfd.com", Password = string.Empty };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void GivenAnInvalidPassword_ShouldHaveValidationError()
        {
            //Arrange
            var model = new UserRequest() { Email = "sdsfdsd@fdgdfd.com", Password = "546" };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void GivenValidPassword_ShouldNotHaveValidationError()
        {
            //Arrange
            var model = new UserRequest() { Email = "sdsfdsd@fdgdfd.com", Password = "123456789" };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Password);
        }
        #endregion

        #region Constructors
        #endregion
    }
}