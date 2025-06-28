using CT03.Models;
using CT03.Services;

public class WeatherService : IWeatherService
{
    private readonly IConfiguration _config;
    private readonly HttpClient _http;

    public WeatherService(IConfiguration config, HttpClient http)
    {
        _config = config;
        _http = http;
    }

    public async Task<WeatherApiResponse> GetForecastAsync()
    {
        bool useMock = _config.GetValue<bool>("UseMockWeather");

        if (useMock)
        {
            return new WeatherApiResponse
            {
                Source = "mock test data",
                Forecasts = GetMockForecasts()
            };
        }

        var forecasts = await FetchFromMeteoAsync();
        return new WeatherApiResponse
        {
            Source = "live from Meteo",
            Forecasts = forecasts
        };
    }

    private ForecastDto[] GetMockForecasts() => new[]
    {
        new ForecastDto { Date = "2025-06-29", TempC = 20, TempF = 68, Summary = "Cloudy" },
        new ForecastDto { Date = "2025-06-30", TempC = 22, TempF = 71.6, Summary = "Sunny" },
        new ForecastDto { Date = "2025-07-01", TempC = 18, TempF = 64.4, Summary = "Rainy" }
    };

    private async Task<ForecastDto[]> FetchFromMeteoAsync()
    {
        var url = _config["OpenMeteo:Url"];
        var meteo = await _http.GetFromJsonAsync<OpenMeteoResponse>(url);

        if (meteo?.Daily?.Time is null)
            return Array.Empty<ForecastDto>();

        var result = new List<ForecastDto>();
        var daily = meteo.Daily;

        for (int i = 0; i < daily.Time.Count; i++)
        {
            var date = daily.Time.ElementAtOrDefault(i);
            var maxC = daily.Temperature_2m_Max.ElementAtOrDefault(i);
            var summary = $"Code {daily.Weathercode.ElementAtOrDefault(i)}";

            result.Add(new ForecastDto
            {
                Date = date,
                TempC = maxC,
                TempF = Math.Round((maxC * 9 / 5) + 32, 1),
                Summary = summary
            });
        }

        return result.ToArray();
    }
}