using CinemaApp.Dtos.Movie;
using CinemaApp.Dtos.Studio;

namespace CinemaApp.Dtos.Schedule
{
    public class ScheduleResponseDto
    {
        public int Id { get; set; }

        public StudioResponseDto? Studio { get; set; }

        public MovieResponseDto? Movie { get; set; }

        public DateTime DateTime { get; set; }

        public int Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


    }
}
