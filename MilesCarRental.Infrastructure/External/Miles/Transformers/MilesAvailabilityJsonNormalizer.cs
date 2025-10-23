using System.Globalization;
using System.Text.Json;

namespace MilesCarRental.Infrastructure.External.Miles.Transformers;

/// <summary>
/// Utilities to normalize provider JSON before mapping to domain.
/// Currently converts numeric "distance" properties to strings to keep a stable contract.
/// </summary>
public static class MilesAvailabilityJsonNormalizer
{
    private static readonly HashSet<string> DistancePropertyNames = new(StringComparer.OrdinalIgnoreCase)
    {
        "distance"
    };

    public static string Normalize(string json)
    {
        using var doc = JsonDocument.Parse(json);
        using var stream = new MemoryStream();
        using (var writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = false }))
        {
            WriteElement(doc.RootElement, writer);
        }
        return System.Text.Encoding.UTF8.GetString(stream.ToArray());
    }

    private static void WriteElement(JsonElement element, Utf8JsonWriter writer)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                writer.WriteStartObject();
                foreach (var prop in element.EnumerateObject())
                {
                    writer.WritePropertyName(prop.Name);
                    if (DistancePropertyNames.Contains(prop.Name) && prop.Value.ValueKind == JsonValueKind.Number)
                    {
                        if (prop.Value.TryGetInt64(out var l))
                        {
                            writer.WriteStringValue(l.ToString(CultureInfo.InvariantCulture));
                        }
                        else if (prop.Value.TryGetDouble(out var d))
                        {
                            writer.WriteStringValue(d.ToString(CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            writer.WriteNullValue();
                        }
                    }
                    else
                    {
                        WriteElement(prop.Value, writer);
                    }
                }
                writer.WriteEndObject();
                break;
            case JsonValueKind.Array:
                writer.WriteStartArray();
                foreach (var item in element.EnumerateArray())
                {
                    WriteElement(item, writer);
                }
                writer.WriteEndArray();
                break;
            case JsonValueKind.String:
                writer.WriteStringValue(element.GetString());
                break;
            case JsonValueKind.Number:
                if (element.TryGetInt64(out var l2))
                    writer.WriteNumberValue(l2);
                else if (element.TryGetDouble(out var d2))
                    writer.WriteNumberValue(d2);
                else
                    writer.WriteNullValue();
                break;
            case JsonValueKind.True:
                writer.WriteBooleanValue(true);
                break;
            case JsonValueKind.False:
                writer.WriteBooleanValue(false);
                break;
            case JsonValueKind.Null:
            case JsonValueKind.Undefined:
            default:
                writer.WriteNullValue();
                break;
        }
    }
}
