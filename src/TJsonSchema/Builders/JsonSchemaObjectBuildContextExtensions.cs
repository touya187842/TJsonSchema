using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace TJsonSchema.Builders;

public static class JsonSchemaObjectBuildContextExtensions
{
    public static TContext MinProperties<TContext, TFactory>(this TContext obj, int minProperties)
        where TContext : IJsonSchemaObjectBuildContext<TFactory>
        where TFactory : IBuildContextFactory<TFactory>
    {
        obj.MinProperties = minProperties;
        return obj;
    }

    public static TContext MaxProperties<TContext, TFactory>(this TContext obj, int maxProperties)
        where TContext : IJsonSchemaObjectBuildContext<TFactory>
        where TFactory : IBuildContextFactory<TFactory>
    {
        obj.MaxProperties = maxProperties;
        return obj;
    }

    public static TContext AdditionalProperties<TContext, TFactory>(this TContext obj, bool allowAny)
        where TContext : IJsonSchemaObjectBuildContext<TFactory>
        where TFactory : IBuildContextFactory<TFactory>
    {
        var root = TFactory.CreateRootBuildContext();
        root.Kind = allowAny ? AllowAnyJsonSchema.Instance : DisallowAnyJsonSchema.Instance;
        obj.AllowAdditionalPropertySchema = root;
        return obj;
    }

    public static IJsonSchemaPropertyBuildContext<TFactory> AddProperty<TContext, TFactory>(
        this TContext obj,
        string propertyName,
        Action<IJsonSchemaRootBuildContext<TFactory>> propertyValue)
        where TContext : IJsonSchemaObjectBuildContext<TFactory>
        where TFactory : IBuildContextFactory<TFactory>
    {
        if (obj.Properties is null)
        {
            obj.Properties = new Dictionary<string, IJsonSchemaPropertyBuildContext<TFactory>>();
        }
        else
        {
            if (obj.Properties.ContainsKey(propertyName))
            {
                throw new ArgumentException($"Property {propertyName} is already added.");
            }
        }

        var template = TFactory.CreateRootBuildContext();
        propertyValue.Invoke(template);
        var property = new JsonSchemaPropertyBuildContext<TFactory> { Name = propertyName, Property = template };
        return property;
    }

    public static TContext AdditionalProperties<TContext, TFactory>(this TContext obj,
        Action<IJsonSchemaRootBuildContext<TFactory>> schemaConfig)
        where TContext : IJsonSchemaObjectBuildContext<TFactory>
        where TFactory : IBuildContextFactory<TFactory>
    {
        var additional = TFactory.CreateRootBuildContext();
        schemaConfig.Invoke(additional);
        obj.AllowAdditionalPropertySchema = additional;
        return obj;
    }

    public static TContext PatternProperty<TContext, TFactory>(
        this TContext obj,
        [StringSyntax(StringSyntaxAttribute.Regex)]
        string regex,
        Action<IJsonSchemaRootBuildContext<TFactory>> schemaConfig)
        where TContext : IJsonSchemaObjectBuildContext<TFactory>
        where TFactory : IBuildContextFactory<TFactory>
    {
        var additional = TFactory.CreateRootBuildContext();
        schemaConfig.Invoke(additional);
        obj.PatternProperties ??= new List<KeyValuePair<Regex, IJsonSchemaRootBuildContext<TFactory>>>();
        obj.PatternProperties.Add(
            new KeyValuePair<Regex, IJsonSchemaRootBuildContext<TFactory>>(new Regex(regex), additional));
        return obj;
    }
}