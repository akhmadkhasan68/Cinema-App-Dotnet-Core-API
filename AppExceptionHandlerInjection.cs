using CinemaApp.Infrastructures.Exceptions;

namespace CinemaApp
{
    public partial class AppServiceProvider
    {
        public void RegisterExceptionHandler()
        {
            _builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            _builder.Services.AddProblemDetails();
        }
    }
}
