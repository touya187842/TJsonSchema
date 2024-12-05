using System;
using System.Text.Json;

namespace TJsonSchema.Json.System.Text;

public static class Extensions
{
    public static IJsonNode? AsTJsonNode(this JsonElement element)
    {
        return element.ValueKind switch
        {
            JsonValueKind.String => new JsonStringAdapter(element),
            JsonValueKind.True or JsonValueKind.False => new JsonBooleanAdapter(element),
            JsonValueKind.Object => new JsonObjectAdapter(element),
            JsonValueKind.Array => new JsonArrayAdapter(element),
            JsonValueKind.Null => default(IJsonNode?),
            _ => throw new NotSupportedException($"Unsupported Json kind: {element.ValueKind}")
        };
    }
}