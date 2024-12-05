using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaObjectProperty : JsonSchemaBase<IJsonObject>, IJsonSchemaObject
{
    private readonly string PropertyName;
    private readonly IJsonSchema Schema;

    public JsonSchemaObjectProperty(string propertyName, IJsonSchema schema)
    {
        PropertyName = propertyName;
        Schema = schema;
    }

    public override bool Validate(IJsonObject value)
    {
        return value.ContainsKey(PropertyName) is false || Schema.Validate(value[PropertyName]);
    }
}