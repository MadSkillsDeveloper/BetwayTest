using Betway.Service.Web.Api.DTO;

namespace Betway.Service.Web.Api.Services
{
    public interface IUserService
    {
        Task<bool> Login(UserRequest userLoginRequest);
        Task RegisterUser(UserRequest userRegisterRequest);
    }
}
