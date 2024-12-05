using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonNumberComparer : NullableComparerBase<IJsonNumber>
{
    internal static readonly JsonNumberComparer Instance = new JsonNumberComparer();
    
    protected override bool NotNullEquals(IJsonNumber x, IJsonNumber y)
    {
        return x.Value == y.Value;
    }

    public override int GetHashCode(IJsonNumber number)
    {
        return number.Value.GetHashCode();
    }
}