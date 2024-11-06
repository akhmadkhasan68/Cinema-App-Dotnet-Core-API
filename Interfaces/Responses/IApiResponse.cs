namespace CinemaApp.Interfaces.Responses
{
    public interface IApiResponse<T>
    {
        public int Status { get; set; }
        
        public string Message { get; set; }
        
        public T Data { get; set; }
    }
}
