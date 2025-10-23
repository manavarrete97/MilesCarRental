using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MilesCarRental.Domain.Serialization;

/// <summary>
/// Json converter that reads numbers, booleans or strings and returns their raw text as a string.
/// Useful when providers sometimes send numeric fields as numbers and sometimes as strings.
/// </summary>
public sealed class FlexibleStringConverter : JsonConverter<string?>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.String => reader.GetString(),
            JsonTokenType.Number => reader.TryGetInt64(out var l) ? l.ToString() : reader.TryGetDouble(out var d) ? d.ToString(System.Globalization.CultureInfo.InvariantCulture) : null,
            JsonTokenType.True => "true",
            JsonTokenType.False => "false",
            JsonTokenType.Null => null,
            _ => reader.GetString()
        };
    }

    public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }
        writer.WriteStringValue(value);
    }
}
