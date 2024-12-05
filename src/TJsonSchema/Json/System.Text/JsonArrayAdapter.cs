using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace TJsonSchema.Json.System.Text;

internal class JsonArrayAdapter : IJsonArray
{
    private readonly JsonElement Element;

    public int Count => Element.GetArrayLength();

    public JsonArrayAdapter(JsonElement element)
    {
        Debug.Assert(element.ValueKind == JsonValueKind.Array);

        Element = element;
    }

    public IEnumerator<IJsonNode?> GetEnumerator()
    {
        return Element.EnumerateArray().Select(item => Extensions.AsTJsonNode(item)).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IJsonNode? this[int index] => throw new NotImplementedException();
}