using CurrencyExchangeAPI.ConfigSettings;
using CurrencyExchangeAPI.ExchangeClient.Interfaces;
using CurrencyExchangeAPI.Models;
using Microsoft.Extensions.Options;
using Refit;

namespace CurrencyExchangeAPI.ExchangeClient.Services
{
    public class ExchangeClientService
    {
        private readonly IExchangeClient _exchangeClient;
        private readonly ExchangeClientSettings _exchangeClientSettings;
        public ExchangeClientService(IOptions<ExchangeClientSettings> options) { 
            _exchangeClientSettings = options.Value;
            _exchangeClient = RestService.For<IExchangeClient>(_exchangeClientSettings.BaseURL);
            
        }
        public async Task<RatesResponse> GetExchangeRatesAsync(GetRatesInput ratesInput)
        {


            var exchangeCallTasks = ratesInput.Dates.Select(async p => await _exchangeClient.GetRates(p, _exchangeClientSettings.APIKey, ratesInput.BaseCurrency, ratesInput.TargetCurrency));
            var allrates = await Task.WhenAll(exchangeCallTasks);

            var maxRate = allrates.MaxBy(f => f.Rates.FirstOrDefault(k => k.Key == ratesInput.TargetCurrency).Value);
            var minRate = allrates.MinBy(f => f.Rates.FirstOrDefault(k => k.Key == ratesInput.TargetCurrency).Value);
            var avg = allrates.Average(f => f.Rates.FirstOrDefault(k => k.Key == ratesInput.TargetCurrency).Value);
            var response = new RatesResponse
            {
                MinimumRate = minRate.Rates.FirstOrDefault(k => k.Key == ratesInput.TargetCurrency).Value,
                MinimumOnDate = minRate.Date,
                MaximumRate = maxRate.Rates.FirstOrDefault(k => k.Key == ratesInput.TargetCurrency).Value,
                MaximumOnDate = maxRate.Date,
                AverageRate = avg
            };

            return response;
        }
    }
}
