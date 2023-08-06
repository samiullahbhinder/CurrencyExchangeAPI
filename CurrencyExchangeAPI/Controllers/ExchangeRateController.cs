using CurrencyExchangeAPI.ExchangeClient.Services;
using CurrencyExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchangeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRateController : ControllerBase
    {
        private readonly ILogger<ExchangeRateController> _logger;
        private readonly ExchangeClientService _exchangeClientService;
        public ExchangeRateController(ILogger<ExchangeRateController> logger, ExchangeClientService exchangeClientService)
        {
            _logger = logger;
            _exchangeClientService = exchangeClientService;
        }

        [HttpPost(Name = "GetCurrencyRates")]
        public async Task<RatesResponse> Get([FromBody] GetRatesInput ratesInput)
        {
            var rates =  await _exchangeClientService.GetExchangeRatesAsync(ratesInput);
            return rates;
        }
    }
}