using Newtonsoft.Json;

namespace CurrencyExchangeAPI.ExchangeClient.ResponseDTOs
{
    public class ExchangeRate
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty("historical")]
        public bool Historical { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("rates")]
        public IDictionary<string, double> Rates { get; set; }
    }
    //public class Rates
    //{
    //    [JsonProperty("SEK")]
    //    public double SEK { get; set; }
    //}
}
