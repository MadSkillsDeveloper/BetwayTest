using Betway.Service.Web.Api.DataContext;
using Betway.Service.Web.Api.DTO;
using Betway.Service.Web.Api.Services;
using Betway.Service.Web.Api.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Betway.Service.Web.Api.Extensions
{
    public static class ApplicationServiceCollection
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Methods
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<BetwayDbContext>(options =>
            {
                options.UseInMemoryDatabase(connectionString);
            });
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<DbContext, BetwayDbContext>();
            services.AddScoped<IRepository<User>, BetwayRepository<User>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IValidator<UserRequest>, UserValidator>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
        #endregion

        #region Constructors
        #endregion
    }
}
