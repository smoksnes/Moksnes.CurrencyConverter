using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moksnes.CurrencyConverter.Shared;

namespace Moksnes.CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public async Task<IActionResult> Get()
        {
            return Ok(await _currencyService.GetCurrenciesAsync(WellKnownCurrencies.SEK));
        }
    }
}
