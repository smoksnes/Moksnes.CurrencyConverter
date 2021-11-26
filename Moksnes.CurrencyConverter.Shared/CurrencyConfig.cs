namespace Moksnes.CurrencyConverter.Shared;

public class CurrencyConfig
{
    public string BaseUri { get; set; }
    public string LatestWithBase { get; set; }

    public const string ConfigName = "Currency";
    public const string ClientName = "exchange-rate";
}