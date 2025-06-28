namespace CT03.Helpers
{
    public static class WeatherCodes
    {
        private static readonly Dictionary<int, string> _map = new()
        {
            [0] = "Clear",
            [1] = "Mainly clear",
            [2] = "Partly cloudy",
            [3] = "Overcast",
            [45] = "Fog",
            [48] = "Depositing rime fog",
            [51] = "Light drizzle",
            [61] = "Light rain",
            [80] = "Rain showers",
            [95] = "Thunderstorm",
        };

        public static string GetSummary(int code) =>
            _map.TryGetValue(code, out var summary) ? summary : "Unknown";
    }
}
