using CinemaApp.Infrastructures.Queue.Email;
using CinemaApp.Interfaces.Services;
using CinemaApp.Services;

namespace CinemaApp
{
    public partial class AppServiceProvider
    {
        public void RegisterServices() {
            _builder.Services.AddScoped<IStudioService, StudioService>();
            _builder.Services.AddScoped<IFacilityService, FacilityService>();
            _builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            _builder.Services.AddScoped<IGenreService, GenreService>();
            _builder.Services.AddScoped<IMovieService, MovieService>();
            _builder.Services.AddScoped<IScheduleService, ScheduleService>();
            _builder.Services.AddScoped<IAuthService, AuthService>();
            _builder.Services.AddScoped<ITicketService, TicketService>();
            _builder.Services.AddScoped<IEmailService, EmailService>();
            _builder.Services.AddScoped<IEmailQueue, InMemoryEmailQueue>();
        }
    }
}
