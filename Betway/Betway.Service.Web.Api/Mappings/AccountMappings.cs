using AutoMapper;
using Betway.Service.Web.Api.DataContext;
using Betway.Service.Web.Api.DTO;

namespace Betway.Service.Web.Api.Mappings
{
    public class AccountMappings : Profile
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Methods
        #endregion

        #region Constructors
        public AccountMappings()
        {
            CreateMap<UserRequest, User>()
                .ConvertUsing<UserModelConverter>();

            CreateMap<User, UserRequest>();
        }
        #endregion

        #region Private Classes
        private class UserModelConverter : ITypeConverter<UserRequest, User>
        {
            #region Fields
            #endregion

            #region Properties
            #endregion

            #region Methods
            public User Convert(
                UserRequest source,
                User destination,
                ResolutionContext context)
            {

                return new User(
                    source.Email,
                    BCrypt.Net.BCrypt.HashPassword(source.Password));
            }
            #endregion

            #region Constructors
            #endregion
        }
        #endregion

    }


}
