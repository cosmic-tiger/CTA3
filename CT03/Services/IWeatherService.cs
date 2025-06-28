using CT03.Models;

namespace CT03.Services
{
    public interface IWeatherService
    {
        Task<WeatherApiResponse> GetForecastAsync();
    }
}
