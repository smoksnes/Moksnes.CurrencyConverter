using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;
using Moksnes.CurrencyConverter.Models;
using System.Diagnostics;
using Moksnes.CurrencyConverter.Shared;

namespace Moksnes.CurrencyConverter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICurrencyService _currencyService;

        public HomeController(ILogger<HomeController> logger, ICurrencyService currencyService)
        {
            _logger = logger;
            _currencyService = currencyService;
        }

        public async Task<IActionResult> Index()
        {

            var currencies = await _currencyService.GetCurrenciesAsync(WellKnownCurrencies.SEK);
            var model = new HomeModel()
            {
                Currencies = currencies.ToDictionary(x => x.Key.Value, y => y.Value),
                SourceCurrency = WellKnownCurrencies.SEK.Value,
                TargetCurrency = WellKnownCurrencies.EUR.Value
            };

            return View(model);
        }

        public async Task<IActionResult> Change(HomeModel input)
        {

            var currencies = await _currencyService.GetCurrenciesAsync(new Currency(input.TargetCurrency));
            var model = new HomeModel()
            {
                Currencies = currencies.ToDictionary(x => x.Key.Value, y => y.Value),
                TargetCurrency = input.SourceCurrency,
                SourceCurrency = input.TargetCurrency,
                Amount = input.Amount
            };
            return View("Index", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class HomeModel
    {
        public IDictionary<string, decimal> Currencies { get; set; } = new Dictionary<string, decimal>();
        public string SourceCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public int Amount { get; set; } = 100;

        public decimal Target
        {
            get
            {
                if (Currencies.ContainsKey(TargetCurrency))
                    return Amount * Currencies[TargetCurrency];
                return 0;
            }
        }
    }
}