using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moksnes.CurrencyConverter.Controllers;
using Moksnes.CurrencyConverter.Shared;
using NSubstitute;
using Xunit;

namespace Moksnes.CurrencyConverter.Tests;

public class HomeControllerTests
{
    private HomeController controller;
    private ICurrencyService? currencyService;
    private Dictionary<Currency, decimal> currency;

    public HomeControllerTests()
    {
        currencyService = Substitute.For<ICurrencyService>();
        var logger = Substitute.For<ILogger<HomeController>>();
        controller = new HomeController(logger, currencyService);
        currency = new Dictionary<Currency, decimal>()
        {
            {new Currency("FOO"), 1.1m},
            {new Currency("BAR"), 1.2m},
            {WellKnownCurrencies.EUR, 1.4m},
            {WellKnownCurrencies.SEK, 1.5m}
        };
    }

    [Fact]
    public async Task GivenCurrency_WhenChange_ShouldReturnReversedCurrenciesAndKeepAmount()
    {
        var input = new HomeModel()
        {
            Amount = 255,
            SourceCurrency = "FOO",
            TargetCurrency = "BAR"
        };

        var expected = new HomeModel()
        {
            TargetCurrency = "FOO",
            SourceCurrency = "BAR",
            Amount = 255,
            Currencies = currency.ToDictionary(x => x.Key.Value, x => x.Value)
        };

        currencyService.GetCurrenciesAsync(new Currency(expected.SourceCurrency)).Returns(currency);

        var actionResult = await controller.Change(input);
        var viewResult = Assert.IsType<ViewResult>(actionResult);
        var model = Assert.IsAssignableFrom<HomeModel>(viewResult.ViewData.Model);
        model.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GivenCurrency_WhenIndex_ShouldReturnValidViewModel()
    {
        var expected = new HomeModel()
        {
            TargetCurrency = WellKnownCurrencies.EUR.Value,
            SourceCurrency = WellKnownCurrencies.SEK.Value,
            Currencies = currency.ToDictionary(x => x.Key.Value, x => x.Value)
        };

        currencyService.GetCurrenciesAsync(WellKnownCurrencies.SEK).Returns(currency);

        var actionResult = await controller.Index();
        var viewResult = Assert.IsType<ViewResult>(actionResult);
        var model = Assert.IsAssignableFrom<HomeModel>(viewResult.ViewData.Model);
        model.Should().BeEquivalentTo(expected);
    }
}