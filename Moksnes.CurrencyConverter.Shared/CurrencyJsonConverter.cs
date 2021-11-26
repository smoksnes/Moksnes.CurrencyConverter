using System.Text.Json;
using System.Text.Json.Serialization;

namespace Moksnes.CurrencyConverter.Shared;

public class CurrencyJsonConverter : JsonConverter<Currency>
{
    public override Currency Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        //Not used in deserialization
        return null;
    }
    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value);
    }
}