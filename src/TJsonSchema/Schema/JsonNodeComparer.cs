using System;
using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonNodeComparer : NullableComparerBase<IJsonNode>
{
    internal static readonly JsonNodeComparer Instance = new JsonNodeComparer();

    protected override bool NotNullEquals(IJsonNode x, IJsonNode y)
    {
        switch (x)
        {
            case IJsonObject objectX when y is IJsonObject objectY:
                return JsonObjectComparer.Instance.Equals(objectX, objectY);
            case IJsonArray arrayX when y is IJsonArray arrayY:
                return JsonArrayComparer.Instance.Equals(arrayX, arrayY);
            case IJsonString stringX when y is IJsonString stringY:
                return JsonStringComparer.Instance.Equals(stringX, stringY);
            case IJsonNumber numberX when y is IJsonNumber numberY:
                return JsonNumberComparer.Instance.Equals(numberX, numberY);
            case IJsonBoolean boolX when y is IJsonBoolean boolY:
                return JsonBooleanComparer.Instance.Equals(boolX, boolY);
            default:
                return false;
        }
    }

    public override int GetHashCode(IJsonNode array)
    {
        throw new NotImplementedException();
    }
}