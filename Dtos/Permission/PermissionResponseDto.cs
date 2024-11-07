namespace CinemaApp.Dtos.Permission
{
    public class PermissionResponseDto
    {
        public int Id { get; set; }

        public string Key { get; set; } = null!;

        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
