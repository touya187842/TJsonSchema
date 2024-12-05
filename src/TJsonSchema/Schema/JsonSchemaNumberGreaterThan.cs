using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaNumberGreaterThan : JsonSchemaBase<IJsonNumber>, IJsonSchemaNumber
{
    private readonly double GreaterThan;

    public JsonSchemaNumberGreaterThan(double greaterThan)
    {
        GreaterThan = greaterThan;
    }

    public override bool Validate(IJsonNumber number)
    {
        return number.Value > GreaterThan;
    }
}