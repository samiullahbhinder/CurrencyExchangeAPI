namespace CurrencyExchangeAPI.Models
{
    public class RatesResponse
    {
        public double MinimumRate { get; set; }
        public double MaximumRate { get; set; }
        public double AverageRate { get; set; }
        public string MinimumOnDate { get; set; }
        public string MaximumOnDate { get; set; }
    }
}
