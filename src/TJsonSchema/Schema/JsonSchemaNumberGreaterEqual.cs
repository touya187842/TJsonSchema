using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaNumberGreaterEqual : JsonSchemaBase<IJsonNumber>, IJsonSchemaNumber
{
    private readonly double GreaterEqual;

    public JsonSchemaNumberGreaterEqual(double greaterEqual)
    {
        GreaterEqual = greaterEqual;
    }

    public override bool Validate(IJsonNumber number)
    {
        return number.Value >= GreaterEqual;
    }
}