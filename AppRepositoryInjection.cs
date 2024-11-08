using CinemaApp.Interfaces.Repositories;
using CinemaApp.Repositories;

namespace CinemaApp
{
    public partial class AppServiceProvider
    {
        public void RegisterRepository() {
            _builder.Services.AddScoped<IStudioRepository, StudioRepository>();
            _builder.Services.AddScoped<IFacilityRepository, FacilityRepository>();
            _builder.Services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            _builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            _builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            _builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
            _builder.Services.AddScoped<IUserRepository, UserRepository>();
            _builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            _builder.Services.AddScoped<ITicketRepository, TicketRepository>();
            _builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}
