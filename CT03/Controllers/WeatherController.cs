using Microsoft.AspNetCore.Mvc;

using CT03.Models;     // For ForecastDto
using CT03.Services;   // For IWeatherService


namespace CT03.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _weatherService.GetForecastAsync();
            return Ok(result);
        }
    }





}
