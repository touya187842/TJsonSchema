using System.Diagnostics;
using System.Text.Json;

namespace TJsonSchema.Json.System.Text;

internal class JsonNumberAdapter : IJsonNumber
{
    private readonly JsonElement Element;

    public JsonNumberAdapter(JsonElement element)
    {
        Debug.Assert(element.ValueKind == JsonValueKind.Number);

        Element = element;
    }

    public double Value => Element.GetDouble();
}