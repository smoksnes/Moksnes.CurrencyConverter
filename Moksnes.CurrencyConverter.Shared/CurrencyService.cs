using System.Collections.Immutable;
using System.Net.Http.Json;
using Microsoft.Extensions.Options;

namespace Moksnes.CurrencyConverter.Shared;

/// <summary>
/// Fetches rates from external API.
/// </summary>
public class CurrencyService : ICurrencyService
{
    private readonly HttpClient client;
    private readonly IOptions<CurrencyConfig> config;

    public CurrencyService(IHttpClientFactory httpClientFactory, IOptions<CurrencyConfig> config)
    {
        this.client = httpClientFactory.CreateClient(CurrencyConfig.ClientName);
        this.config = config;
    }

    public async Task<IDictionary<Currency, decimal>> GetCurrenciesAsync(Currency baseCurrency)
    {
        var endpoint = config.Value.LatestWithBase.Replace("{base}", baseCurrency.Value);
        var result = await client.GetFromJsonAsync<Root>(endpoint);
        return result.Rates.OrderBy(x => x.Key).ToImmutableDictionary(x => new Currency(x.Key), y => y.Value);
    }
}