using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers;

[ApiController]
[Route("[controller]")]
public class StudioController : ControllerBase {
    private static readonly string[] Name = new[]
    {
        "Studio 1", "Studio 2", "Studio 3", "Studio 4", "Studio 5"
    };

    private readonly ILogger<StudioController> _logger;

    public StudioController(ILogger<StudioController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Studio> Get()
    {
        return Enumerable.Range(0, 4).Select(index => new Studio
        {
            Id = index,
            Name = Name[index],
            Capacity = index * 100,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        })
        .ToArray();
    }
}
