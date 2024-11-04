using CinemaApp.Models;

namespace CinemaApp.Dtos
{
    public class StudioDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Capacity { get; set; }

        public List<StudioFacility> StudioFacilities { get; set; } = [];

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
