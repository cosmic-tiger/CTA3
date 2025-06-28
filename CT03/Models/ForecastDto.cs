namespace CT03.Models
{
    public class ForecastDto
    {
        public string Date { get; set; } = "";
        public double TempC { get; set; }
        public double TempF { get; set; }
        public string Summary { get; set; } = "";
    }
}
