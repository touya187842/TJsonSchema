using System.Collections.Generic;

namespace TJsonSchema.Builders;

public static class JsonSchemaPropertyBuildContextExtensions
{
    public static T Required<T>(this T property, bool required = true) where T : IJsonSchemaPropertyBuildContext
    {
        property.IsRequired = required;
        return property;
    }

    public static T DependsOn<T>(this T property, string otherPropertyName) where T : IJsonSchemaPropertyBuildContext
    {
        property.Dependencies ??= new List<object>();
        property.Dependencies.Add(otherPropertyName);
        return property;
    }
}