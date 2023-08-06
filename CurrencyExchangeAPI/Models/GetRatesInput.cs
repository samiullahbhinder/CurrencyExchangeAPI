namespace CurrencyExchangeAPI.Models
{
    public class GetRatesInput
    {
        public List<string> Dates { get; set; }
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
    }
}
