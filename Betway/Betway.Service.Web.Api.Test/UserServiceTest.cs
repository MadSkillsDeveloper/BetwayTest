using Betway.Service.Web.Api.DTO;
using Betway.Service.Web.Api.Services;
using FluentAssertions;
using Xunit;

namespace Betway.Service.Web.Api.Test
{
    public class UserServiceTest
    {
        #region Fields
        private readonly IUserService _userService;
        #endregion

        #region Properties
        #endregion

        #region Methods
        [Fact]
        public async Task GivenUsernameAndPasswordAreValid_ShouldNotHaveAnError()
        {
            //Arrange

            //Act
            var sut = await _userService.Login(
                new UserRequest
                {
                    Email = "lulamile.gaji@gmail.com",
                    Password = "12345678"
                });

            //Assert
            sut.Should().BeTrue();
        }

        [Fact]
        public async Task GivenInvalidPassword_ShouldReturnFalse()
        {
            //Arrange

            //Act
            var sut = await _userService.Login(
                new UserRequest
                {
                    Email = "lulamile.gaji@gmail.com",
                    Password = "lulamile"
                });

            //Assert
            sut.Should().BeFalse();
        }
        #endregion

        #region Constructors
        public UserServiceTest(IUserService userService)
        {
            _userService = userService;
        }
        #endregion
    }
}
