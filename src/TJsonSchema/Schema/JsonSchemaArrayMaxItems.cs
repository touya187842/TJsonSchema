using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaArrayMaxItems : JsonSchemaBase<IJsonArray>, IJsonSchemaArray
{
    private readonly int MaxItems;

    public JsonSchemaArrayMaxItems(int maxItems)
    {
        MaxItems = maxItems;
    }

    public override bool Validate(IJsonArray value)
    {
        return value.Count <= MaxItems;
    }
}