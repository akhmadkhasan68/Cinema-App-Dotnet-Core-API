namespace CinemaApp.Interfaces.Requests
{
    public interface IPaginationRequest
    {
        public int? Page { get; set; }

        public int? PerPage { get; set; }        
    }
}
