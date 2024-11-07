using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApp.Dtos.Movie;
using CinemaApp.Dtos.Studio;

namespace CinemaApp.Dtos.Schedule
{
    public class ScheduleDto
    {
        public int Id { get; set; }

        public int StudioId { get; set; }

        public int MovieId { get; set; }

        public DateTime DateTime { get; set; }

        public int Price { get; set; }

        public StudioDto? Studio { get; set; } = null!;

        public MovieDto? Movie { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set;}
    }
}
