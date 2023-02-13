using Betway.Service.Web.Api.DataContext;
using Betway.Service.Web.Api.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Betway.Service.Web.Api.Test
{
    public class Startup
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Methods
        //public static void ConfigureHost(IHostBuilder hostBuilder)
        //{
        //    hostBuilder.ConfigureWebHost(webHostBuilder => webHostBuilder
        //    .UseTestServer(options => options.PreserveExecutionContext = true)
        //    .UseStartup<Startup>());

        //}

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BetwayDbContext>(opt => opt.UseInMemoryDatabase("Betway"))
                .AddRepositories()
                .AddApplicationServices();

            var serviceProvider = services.BuildServiceProvider();
            using var serviceScope = serviceProvider.CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<BetwayDbContext>();
            context.Database.EnsureCreated();

        }
        #endregion

        #region Constructors
        public Startup()
        {

        }
        #endregion
    }
}
