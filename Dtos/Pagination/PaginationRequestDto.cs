namespace CinemaApp.Dtos.Pagination
{
    public class PaginationRequestDto
    {
        public string? Keyword { get; set; } = null;

        public int Page { get; set; } = 1;

        public int PerPage { get; set; } = 10;

        public string? SortBy { get; set; } = null;

        public string? Order { get; set; } = null;
    }
}
