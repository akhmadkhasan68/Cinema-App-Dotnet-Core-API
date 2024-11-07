namespace CinemaApp.Dtos.Schedule
{
    public class ScheduleRequestDto
    {
        public int StudioId { get; set; }

        public int MovieId { get; set; }

        public DateTime DateTime { get; set; }

        public int Price { get; set; }
    }
}
