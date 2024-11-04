namespace CinemaApp.Responses
{
    public class StudioResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
