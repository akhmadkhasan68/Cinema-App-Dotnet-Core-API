using System.Net;

namespace CinemaApp.Infrastructures.Responses
{
    // Adding = VoidResult as default type parameter
    public class ApiResponse
    {
        public int Status { get; set; }
        public string Message { get; set; } = null!;

        public static ApiResponse Success(string message = "OK")
        {
            return new ApiResponse
            {
                Status = (int)HttpStatusCode.OK,
                Message = message,
            };
        }

        public static ApiResponse Error(string message, int statusCode = (int)HttpStatusCode.InternalServerError)
        {
            return new ApiResponse
            {
                Status = statusCode == 0 ? (int)HttpStatusCode.InternalServerError : statusCode,
                Message = message
            };
        }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T? Data { get; set; }

        public static ApiResponse<T> Success(T data, string message = "OK")
        {
            return new ApiResponse<T>
            {
                Status = (int)HttpStatusCode.OK,
                Message = message,
                Data = data
            };
        }
    }
    
}
