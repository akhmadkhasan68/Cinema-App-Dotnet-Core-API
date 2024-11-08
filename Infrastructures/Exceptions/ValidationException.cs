using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CinemaApp.Infrastructures.Exceptions
{
    public class ValidationException(ModelStateDictionary modelState) : Exception("One or more validation failures have occurred.")
    {
        public List<string> Errors { get; } = modelState.Values.SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();
    }
}
