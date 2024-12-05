using System.Collections.Generic;

namespace TJsonSchema.Builders;

public static class JsonSchemaPropertyBuildContextExtensions
{
    public static TContext Required<TContext, TFactory>(this TContext property, bool required = true)
        where TContext : IJsonSchemaPropertyBuildContext<TFactory>
        where TFactory : IBuildContextFactory<TFactory>
    {
        property.IsRequired = required;
        return property;
    }

    public static TContext DependsOn<TContext, TFactory>(this TContext property, string otherPropertyName)
        where TContext : IJsonSchemaPropertyBuildContext<TFactory>
        where TFactory : IBuildContextFactory<TFactory>
    {
        property.Dependencies ??= new List<object>();
        property.Dependencies.Add(otherPropertyName);
        return property;
    }
}