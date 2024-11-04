using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers;

[ApiController]
[Route("studios")]
public class StudioController : ControllerBase {
    private readonly ILogger<StudioController> _logger;
    public StudioController(ILogger<StudioController> logger)
    {
        _logger = logger;
    }
}
