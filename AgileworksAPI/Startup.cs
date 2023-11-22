using AgileworksAPI.DatabaseContexts;
using AgileworksAPI.Filters;
using AgileworksAPI.Interfaces.Repositories;
using AgileworksAPI.Interfaces.Services;

namespace AgileworksAPI.Core.Startup;

public class Startup
{
    public IConfiguration config
    {
        get;
    }
    public Startup(IConfiguration configuration)
    {
        config = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // CORS
        services.AddCors(options =>
        {
            options.AddPolicy(name: "AppOrigins",
            builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
        });

        // DBContexts
        services.AddDbContext<MainDatabaseContext>();

        // Repositories
        services.AddScoped<ITicketRepository, TicketRepository>();

        // Services
        services.AddScoped<ITicketService, TicketService>();

        // Controllers
        services.AddControllers(options =>
        {
            options.Filters.Add<NotFoundExceptionFilterAttribute>();
        });

        // Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseCors("AppOrigins");
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.MapControllers();
        app.Run();
    }
}
