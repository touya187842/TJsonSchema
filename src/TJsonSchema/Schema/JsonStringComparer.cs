using System.Linq;
using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonStringComparer : NullableComparerBase<IJsonString>
{
    internal static readonly JsonStringComparer Instance = new JsonStringComparer();

    protected override bool NotNullEquals(IJsonString x, IJsonString y)
    {
        return string.Equals(x.Value, y.Value);
    }

    public override int GetHashCode(IJsonString @string)
    {
        return @string.Value.Aggregate(0, (hash, @char) => unchecked(hash * 31) ^ @char);
    }
}