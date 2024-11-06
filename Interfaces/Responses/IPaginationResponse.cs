namespace CinemaApp.Interfaces.Responses
{
    public interface IPaginationResponse<T>
    {
        public IPaginationMeta Meta { get; set; }

        public List<T> Data { get; set; }
    }
}
