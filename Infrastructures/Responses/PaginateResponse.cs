using System.Net;

namespace CinemaApp.Infrastructures.Responses
{
    public class PaginateResponse<T>
    {
        public int Status { get; set; }
        
        public string Message { get; set; } = null!;
        
        public List<T> Data { get; set; } = null!;

        public PaginateResponseMetadata Metadata { get; set; } = null!;

        public static PaginateResponse<T> Success(List<T> data, int page, int perPage, int totalData)
        {
            return new PaginateResponse<T>
            {
                Status = (int)HttpStatusCode.OK,
                Message = "OK",
                Data = data,
                Metadata = PaginateResponseMetadata.Success(page, perPage, totalData)
            };
        }
    }
}
