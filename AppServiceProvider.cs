using System.Text;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Infrastructures.Jobs.TicketExpired;
using CinemaApp.Infrastructures.Middlewares;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Services;
using CinemaApp.Repositories;
using CinemaApp.Services;
using CinemaApp.Utils.Constans;
using CinemaApp.Utils.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Quartz;

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
            _builder.Services.AddEndpointsApiExplorer();
            _builder.Services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo{
                    Title = "CinemaApp",
                    Version = "v1"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            // Add database context
            _builder.Services.AddDbContext<ApplicationDBContext>(options => {
                options.UseSqlServer(_builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention();
            });

            // Middleware
            _builder.Services.AddScoped<LoggingMiddleware>();

            // Dependency Injection for Repositories
            _builder.Services.AddScoped<IStudioRepository, StudioRepository>();
            _builder.Services.AddScoped<IFacilityRepository, FacilityRepository>();
            _builder.Services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            _builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            _builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            _builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
            _builder.Services.AddScoped<IUserRepository, UserRepository>();
            _builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            _builder.Services.AddScoped<ITicketRepository, TicketRepository>();

            // Dependency Injection for Services
            _builder.Services.AddScoped<IStudioService, StudioService>();
            _builder.Services.AddScoped<IFacilityService, FacilityService>();
            _builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            _builder.Services.AddScoped<IGenreService, GenreService>();
            _builder.Services.AddScoped<IMovieService, MovieService>();
            _builder.Services.AddScoped<IScheduleService, ScheduleService>();
            _builder.Services.AddScoped<IAuthService, AuthService>();
            _builder.Services.AddScoped<ITicketService, TicketService>();

            // Add Quartz Scheduler Service for Cron Job
            _builder.Services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();

                var jobKey = new JobKey("TicketExpiredJob", "Ticket");

                // Configure job
                q.AddJob<TicketExpiredJob>(j => j.WithIdentity(jobKey));

                // Configure trigger
                q.AddTrigger(t => t
                    .ForJob(jobKey)
                    .WithIdentity("TicketExpiredJobTrigger")
                    .WithCronSchedule("0/5 * * * * ?") // Run every 5 seconds
                );
            });

            _builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);


            // JWT Authentication
            _builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                                    .AddEnvironmentVariables();

            var configuration = _builder.Configuration;

            AppSettingHelper.Initialize(configuration);

            _builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = AppSettingHelper.GetValue<string>("Jwt:Issuer"),
                    ValidAudience = AppSettingHelper.GetValue<string>("Jwt:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettingHelper.GetValue<string>("Jwt:Key")!))
                };
            });
        }
    }
}
