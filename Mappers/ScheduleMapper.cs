using CinemaApp.Dtos.Schedule;
using CinemaApp.Models;

namespace CinemaApp.Mappers
{
    public static class ScheduleMapper
    {
        public static ScheduleDto ToDto(this Schedule schedule)
        {
            return new ScheduleDto
            {
                Id = schedule.Id,
                MovieId = schedule.MovieId,
                StudioId = schedule.StudioId,
                DateTime = schedule.DateTime,
                Price = schedule.Price,
                Movie = schedule.Movie?.ToDto() ?? null,
                Studio = schedule.Studio?.ToDto() ?? null,
                CreatedAt = schedule.CreatedAt,
                UpdatedAt = schedule.UpdatedAt,
            };
        }   

        public static ScheduleResponseDto ToResponse(this ScheduleDto scheduleDto)
        {
            return new ScheduleResponseDto
            {
                Id = scheduleDto.Id,
                Movie = scheduleDto.Movie?.ToResponse() ?? null,
                Studio = scheduleDto.Studio?.ToResponse() ?? null,
                DateTime = scheduleDto.DateTime,
                Price = scheduleDto.Price,
                CreatedAt = scheduleDto.CreatedAt,
                UpdatedAt = scheduleDto.UpdatedAt,
            };
        }     

        public static Schedule ToModel(this ScheduleRequestDto scheduleRequestDto)
        {
            return new Schedule
            {
                MovieId = scheduleRequestDto.MovieId,
                StudioId = scheduleRequestDto.StudioId,
                DateTime = scheduleRequestDto.DateTime,
                Price = scheduleRequestDto.Price,
            };
        }
    }
}
