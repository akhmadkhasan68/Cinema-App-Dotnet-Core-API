namespace CinemaApp.Interfaces.Requests
{
    public interface IPaginationSortRequest
    {
        public string SortBy { get; set; }

        public string SortOrder { get; set; }
    }
}
