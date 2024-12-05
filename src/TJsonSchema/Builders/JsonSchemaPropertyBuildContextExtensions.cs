using System.Collections.Generic;

namespace TJsonSchema.Builders;

public static class JsonSchemaPropertyBuildContextExtensions
{
    public static IJsonSchemaPropertyBuildContext<TFactory> Required<TFactory>(
        this IJsonSchemaPropertyBuildContext<TFactory> property,
        bool required = true)
        where TFactory : IBuildContextFactory<TFactory>
    {
        property.IsRequired = required;
        return property;
    }

    public static IJsonSchemaPropertyBuildContext<TFactory> DependsOn<TFactory>(
        this IJsonSchemaPropertyBuildContext<TFactory> property, 
        string otherPropertyName)
        where TFactory : IBuildContextFactory<TFactory>
    {
        property.Dependencies ??= new List<object>();
        property.Dependencies.Add(otherPropertyName);
        return property;
    }
}