using Betway.Service.Web.Api.DataContext;
using Betway.Service.Web.Api.Extensions;
using Serilog;

try
{
    var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

    var builder = WebApplication.CreateBuilder(args);

    IConfiguration configuration = builder.Configuration
                        .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", false, true)
                         .Build();

    Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .CreateLogger();

    builder.Host.UseSerilog(Log.Logger);
    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog(Log.Logger);

    var connectionString = configuration.GetConnectionString("DefaultConnection");

    builder.Services.AddDatabase(connectionString)
                    .AddRepositories()
                    .AddApplicationServices();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddCors(opt =>
    {
        opt.AddPolicy(name: MyAllowSpecificOrigins,
                       policy =>
                       {
                           policy.AllowAnyHeader();
                           policy.AllowAnyMethod();
                           policy.AllowAnyOrigin();
                       });
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    using (var serviceScope = app.Services.CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<BetwayDbContext>();
        context.Database.EnsureCreated();
    }

    app.UseCors(MyAllowSpecificOrigins);

    app.UseSerilogRequestLogging();

    app.UseCustomExceptionHandler(Log.Logger);

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
    Log.Information("Application has started...");
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled Exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}

