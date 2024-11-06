namespace CinemaApp.Interfaces.Responses
{
    public interface IPaginationMeta
    {
        public int Page { get; set; }

        public int PerPage { get; set; }

        public int Total { get; set; }

        public int TotalPages { get; set; }
    }
}
