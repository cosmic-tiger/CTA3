namespace CT03.Models
{
    public class WeatherApiResponse
    {
        public string Source { get; set; } = "unknown";
        public ForecastDto[] Forecasts { get; set; } = Array.Empty<ForecastDto>();
    }
}
