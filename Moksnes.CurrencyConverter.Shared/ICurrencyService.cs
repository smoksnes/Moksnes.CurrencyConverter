namespace Moksnes.CurrencyConverter.Shared;

public interface ICurrencyService
{
    Task<IDictionary<Currency, decimal>> GetCurrenciesAsync(Currency baseCurrency);
}