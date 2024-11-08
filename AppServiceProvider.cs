using System.Text;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Infrastructures.Jobs.TicketExpired;
using CinemaApp.Infrastructures.Middlewares;
using CinemaApp.Utils.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Quartz;

namespace CinemaApp
{
    public partial class AppServiceProvider(WebApplicationBuilder builder)
    {
        private readonly WebApplicationBuilder _builder = builder;

        // Add your services here
        public void InitServiceProvider()
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
            _builder.Services.AddDbContextPool<ApplicationDBContext>(options => {
                options.UseSqlServer(_builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention();
            });

            // Middleware
            _builder.Services.AddScoped<LoggingMiddleware>();

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
