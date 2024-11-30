using System.Collections.Generic;

namespace TJsonSchema.Builders;

public static class JsonSchemaPropertyBuilderExtensions
{
    public static T Required<T>(this T property, bool required = true) where T : IJsonSchemaPropertyBuilder
    {
        property.IsRequired = required;
        return property;
    }

    public static T DependsOn<T>(this T property, string otherPropertyName) where T : IJsonSchemaPropertyBuilder
    {
        property.Dependencies ??= new List<object>();
        property.Dependencies.Add(otherPropertyName);
        return property;
    }
}