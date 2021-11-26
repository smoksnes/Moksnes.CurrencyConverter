using System.Text.Json.Serialization;
using System.Web;

namespace Moksnes.CurrencyConverter.Shared
{
    public class Motd
    {
        [JsonPropertyName("msg")]
        public string Msg { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}