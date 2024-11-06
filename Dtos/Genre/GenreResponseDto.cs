namespace CinemaApp.Dtos.Genre
{
    public class GenreResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }  
    }
}
