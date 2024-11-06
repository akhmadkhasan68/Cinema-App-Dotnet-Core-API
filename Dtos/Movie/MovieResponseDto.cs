using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApp.Dtos.Genre;

namespace CinemaApp.Dtos.Movie
{
    public class MovieResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public int DurationInMinutes { get; set; }

        public string Description { get; set; } = null!;

        public GenreResponseDto? Genre { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
