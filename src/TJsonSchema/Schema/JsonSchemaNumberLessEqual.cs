using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaNumberLessEqual : JsonSchemaBase<IJsonNumber>, IJsonSchemaNumber
{
    private readonly double LessEqual;

    public JsonSchemaNumberLessEqual(double lessEqual)
    {
        LessEqual = lessEqual;
    }

    public override bool Validate(IJsonNumber number)
    {
        return number.Value <= LessEqual;
    }
}