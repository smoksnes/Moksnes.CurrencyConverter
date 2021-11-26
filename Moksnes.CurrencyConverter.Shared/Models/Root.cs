using System.Text.Json.Serialization;

namespace Moksnes.CurrencyConverter.Shared;

public class Root
{
    [JsonPropertyName("motd")]
    public Motd Motd { get; set; }
    [JsonPropertyName("Success")]
    public bool Success { get; set; }
    public string @base { get; set; }
    [JsonPropertyName("date")]
    public string Date { get; set; }
    [JsonPropertyName("rates")]
    public Dictionary<string, decimal> Rates { get; set; }
}