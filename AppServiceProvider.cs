using CinemaApp.Infrastructures.Database;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Services;
using CinemaApp.Repositories;
using CinemaApp.Services;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp
{
    public class AppServiceProvider(WebApplicationBuilder builder)
    {
        private readonly WebApplicationBuilder _builder = builder;

        // Add your services here
        public void ConfigureServices()
        {
            _builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add database context
            _builder.Services.AddDbContext<ApplicationDBContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention();
            });

            // Dependency Injection for Repositories
            _builder.Services.AddScoped<IStudioRepository, StudioRepository>();
            _builder.Services.AddScoped<IFacilityRepository, FacilityRepository>();
            _builder.Services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();

            // Dependency Injection for Services
            _builder.Services.AddScoped<IStudioService, StudioService>();
            _builder.Services.AddScoped<IFacilityService, FacilityService>();
        }
    }
}