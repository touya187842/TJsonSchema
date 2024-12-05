using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;

namespace TJsonSchema.Json.System.Text;

internal class JsonObjectAdapter : IJsonObject
{
    private readonly JsonElement Element;

    public IJsonNode this[string key]
    {
        get
        {
            if (TryGetValue(key, out var property))
            {
                Debug.Assert(property is not null);
                return property;
            }

            throw new KeyNotFoundException();
        }
    }

    public IEnumerable<string> Keys => Element.EnumerateObject().Select(property => property.Name);

    public IEnumerable<IJsonNode?> Values => Element.EnumerateObject().Select(property => property.Value.AsTJsonNode());

    public int Count => Element.EnumerateObject().Count();

    public JsonObjectAdapter(JsonElement element)
    {
        Debug.Assert(element.ValueKind == JsonValueKind.Object);

        Element = element;
    }

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out IJsonNode? value)
    {
        if (Element.TryGetProperty(key, out var property) is false)
        {
            value = default;
            return false;
        }

        value = property.AsTJsonNode();
        return true;
    }

    public bool ContainsKey(string key) => Element.TryGetProperty(key, out _);

    public IEnumerator<KeyValuePair<string, IJsonNode?>> GetEnumerator()
    {
        foreach (var property in Element.EnumerateObject())
        {
            yield return new KeyValuePair<string, IJsonNode?>(
                property.Name,
                property.Value.AsTJsonNode());
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}