using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaNumberLessThan : JsonSchemaBase<IJsonNumber>, IJsonSchemaNumber
{
    private readonly double LessThan;

    public JsonSchemaNumberLessThan(double lessThan)
    {
        LessThan = lessThan;
    }

    public override bool Validate(IJsonNumber number)
    {
        return number.Value < LessThan;
    }
}