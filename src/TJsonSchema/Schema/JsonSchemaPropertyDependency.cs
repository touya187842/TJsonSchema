using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaPropertyDependency : JsonSchemaBase<IJsonObject>, IJsonSchemaObject
{
    private readonly string PropertyName;
    private readonly string Dependency;

    public JsonSchemaPropertyDependency(string propertyName, string dependency)
    {
        PropertyName = propertyName;
        Dependency = dependency;
    }

    public override bool Validate(IJsonObject value)
    {
        return value.ContainsKey(PropertyName) is false || value.ContainsKey(Dependency);
    }
}