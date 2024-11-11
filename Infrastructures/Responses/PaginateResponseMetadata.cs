namespace CinemaApp.Infrastructures.Responses
{
    public class PaginateResponseMetadata
    {
        public int Page { get; set; } = 1;

        public int PerPage { get; set; } = 10;

        public int TotalData { get; set; }

        public static PaginateResponseMetadata Success(int page, int perPage, int totalData)
        {
            return new PaginateResponseMetadata
            {
                Page = page,
                PerPage = perPage,
                TotalData = totalData
            };
        }
    }
}
