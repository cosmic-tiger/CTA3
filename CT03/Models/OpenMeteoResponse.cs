namespace CT03.Models
{
    public class OpenMeteoResponse
    {
        public DailySection Daily { get; set; } = new();
    }

    public class DailySection
    {
        public List<string> Time { get; set; } = new();
        public List<double> Temperature_2m_Min { get; set; } = new();
        public List<double> Temperature_2m_Max { get; set; } = new();
        public List<int> Weathercode { get; set; } = new();
    }

}
