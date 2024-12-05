using System.Diagnostics;
using System.Text.Json;

namespace TJsonSchema.Json.System.Text;

internal class JsonBooleanAdapter : IJsonBoolean
{
    private readonly JsonElement Element;

    public JsonBooleanAdapter(JsonElement element)
    {
        Debug.Assert(element.ValueKind == JsonValueKind.True || element.ValueKind == JsonValueKind.False);

        Element = element;
    }

    public bool Value => Element.GetBoolean();
}