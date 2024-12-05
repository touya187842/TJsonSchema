using System.Diagnostics;
using System.Text.Json;

namespace TJsonSchema.Json.System.Text;

public class JsonStringAdapter : IJsonString
{
    private readonly JsonElement Element;

    public JsonStringAdapter(JsonElement element)
    {
        Debug.Assert(element.ValueKind == JsonValueKind.String);

        Element = element;
    }

    public string Value => Element.GetString()!;
}