using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaArrayMinItems : JsonSchemaBase<IJsonArray>, IJsonSchemaArray
{
    private readonly int MinItems;

    public JsonSchemaArrayMinItems(int minItems)
    {
        MinItems = minItems;
    }

    public override bool Validate(IJsonArray value)
    {
        return value.Count >= MinItems;
    }
}