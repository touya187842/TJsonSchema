using System.Linq;
using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonArrayComparer : NullableComparerBase<IJsonArray>
{
    internal static JsonArrayComparer Instance { get; } = new JsonArrayComparer();

    protected override bool NotNullEquals(IJsonArray x, IJsonArray y)
    {
        if (x.Count != y.Count)
        {
            return false;
        }

        return x.SequenceEqual(y, JsonNodeComparer.Instance);
    }

    public override int GetHashCode(IJsonArray array)
    {
        return array.Aggregate(0, (hash, element) => unchecked(hash * 524287) ^ (element is null ? 0 : JsonNodeComparer.Instance.GetHashCode(element)));
    }
}