using System.Net;

namespace CinemaApp.Infrastructures.Responses
{
    public class ApiResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; } = null!;
        public T Data { get; set; } = default!;

        public static ApiResponse<T> Success(T data, string message = "OK")
        {
            return new ApiResponse<T>
            {
                Status = HttpStatusCode.OK.GetHashCode(),
                Message = message,
                Data = data
            };
        }

        public static ApiResponse<T> Error(string message, int statusCode)
        {
            return new ApiResponse<T>
            {
                Status = statusCode == 0 ? HttpStatusCode.InternalServerError.GetHashCode() : statusCode,
                Message = message
            };
        }
    }
}
