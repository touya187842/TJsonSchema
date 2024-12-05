using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonBooleanComparer : NullableComparerBase<IJsonBoolean>
{
    internal static readonly JsonBooleanComparer Instance = new JsonBooleanComparer();
    
    protected override bool NotNullEquals(IJsonBoolean x, IJsonBoolean y)
    {
        return x.Value == y.Value;
    }

    public override int GetHashCode(IJsonBoolean boolean)
    {
        return boolean.Value.GetHashCode();
    }
}