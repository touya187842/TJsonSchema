using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaPropertyRequired : JsonSchemaBase<IJsonObject>, IJsonSchemaObject
{
    private readonly string PropertyName;

    public JsonSchemaPropertyRequired(string propertyName)
    {
        PropertyName = propertyName;
    }

    public override bool Validate(IJsonObject value)
    {
        return value.ContainsKey(PropertyName);
    }
}