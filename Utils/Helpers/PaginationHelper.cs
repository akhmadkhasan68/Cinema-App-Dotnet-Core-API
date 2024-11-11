namespace CinemaApp.Utils.Helpers
{
    public static class PaginationHelper
    {
        public static int CalculateSkip(int page, int perPage)
        {
            return (page - 1) * perPage;
        }
    }
}
