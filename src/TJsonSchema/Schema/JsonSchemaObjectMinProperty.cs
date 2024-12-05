using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaObjectMinProperty : JsonSchemaBase<IJsonObject>, IJsonSchemaObject
{
    private readonly int MinProperty;

    public JsonSchemaObjectMinProperty(int minProperty)
    {
        MinProperty = minProperty;
    }

    public override bool Validate(IJsonObject text)
    {
        return text.Count >= MinProperty;
    }
}