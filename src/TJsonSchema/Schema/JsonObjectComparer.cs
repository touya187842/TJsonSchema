using System;
using System.Collections.Generic;
using System.Linq;
using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonObjectComparer : NullableComparerBase<IJsonObject>
{
    internal static JsonObjectComparer Instance { get; } = new JsonObjectComparer();

    protected override bool NotNullEquals(IJsonObject x, IJsonObject y)
    {
        if (x.Count != y.Count)
        {
            return false;
        }

        var keys = new HashSet<string>(x.Keys, StringComparer.OrdinalIgnoreCase);
        if (keys.IsSubsetOf(y.Keys) is false)
        {
            return false;
        }

        return keys.All(key => JsonNodeComparer.Instance.Equals(x[key], y[key]));
    }

    public override int GetHashCode(IJsonObject obj)
    {
        return obj.Aggregate(0, (hash, kv) =>
        {
            hash = unchecked(hash * 524287) ^ kv.Key.Aggregate(0, (h, @char) => unchecked(h * 31) ^ @char);
            hash = unchecked(hash * 31) ^ (kv.Value is null ? 0 : JsonNodeComparer.Instance.GetHashCode(kv.Value));
            return hash;
        });
    }
}