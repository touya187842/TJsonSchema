using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaObjectMaxProperty : JsonSchemaBase<IJsonObject>, IJsonSchemaObject
{
    private readonly int MaxProperty;

    public JsonSchemaObjectMaxProperty(int maxProperty)
    {
        MaxProperty = maxProperty;
    }

    public override bool Validate(IJsonObject text)
    {
        return text.Count <= MaxProperty;
    }
}