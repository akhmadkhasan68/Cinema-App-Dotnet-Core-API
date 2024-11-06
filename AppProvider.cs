using CinemaApp.Infrastructures.Database;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp
{
    public class AppProvider(WebApplicationBuilder builder)
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
        }
    }
}
