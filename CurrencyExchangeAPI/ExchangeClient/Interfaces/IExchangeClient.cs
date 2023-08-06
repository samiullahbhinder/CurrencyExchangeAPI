using CurrencyExchangeAPI.ExchangeClient.ResponseDTOs;
using Refit;

namespace CurrencyExchangeAPI.ExchangeClient.Interfaces
{
    public interface IExchangeClient
    {
        [Get("/{date}")]
        Task<ExchangeRate> GetRates(string date, string access_key, [AliasAs("base")] string Base, string symbols);
    }
}
