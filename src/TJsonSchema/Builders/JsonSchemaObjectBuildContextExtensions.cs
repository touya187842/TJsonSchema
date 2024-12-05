using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace TJsonSchema.Builders;

public static class JsonSchemaObjectBuildContextExtensions
{
    public static IJsonSchemaObjectBuildContext<TFactory> AsObject<TFactory>(
        this IJsonSchemaRootBuildContext<TFactory> context)
        where TFactory : IBuildContextFactory<TFactory>
    {
        switch (context)
        {
            case { Kind: null }:
            {
                var obj = TFactory.CreateObjectBuildContext();
                context.Kind = obj;
                return obj;
            }
            case { Kind: IJsonSchemaObjectBuildContext<TFactory> obj }:
            {
                return obj;
            }
            default:
                throw new InvalidOperationException();
        }
    }

    public static IJsonSchemaObjectBuildContext<TFactory> MinProperties<TFactory>(
        this IJsonSchemaObjectBuildContext<TFactory> obj, 
        int minProperties)
        where TFactory : IBuildContextFactory<TFactory>
    {
        obj.MinProperties = minProperties;
        return obj;
    }

    public static IJsonSchemaObjectBuildContext<TFactory> MaxProperties<TFactory>(
        this IJsonSchemaObjectBuildContext<TFactory> obj, 
        int maxProperties)
        where TFactory : IBuildContextFactory<TFactory>
    {
        obj.MaxProperties = maxProperties;
        return obj;
    }

    public static IJsonSchemaObjectBuildContext<TFactory> AdditionalProperties<TFactory>(
        this IJsonSchemaObjectBuildContext<TFactory> obj, 
        bool allowAny)
        where TFactory : IBuildContextFactory<TFactory>
    {
        var root = TFactory.CreateRootBuildContext();
        root.Kind = allowAny ? AllowAnyJsonSchema.Instance : DisallowAnyJsonSchema.Instance;
        obj.AllowAdditionalPropertySchema = root;
        return obj;
    }

    public static IJsonSchemaPropertyBuildContext<TFactory> AddProperty<TFactory>(
        this IJsonSchemaObjectBuildContext<TFactory> obj,
        string propertyName,
        Action<IJsonSchemaRootBuildContext<TFactory>> propertyValue)
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

    public static IJsonSchemaObjectBuildContext<TFactory> AdditionalProperties<TFactory>(
        this IJsonSchemaObjectBuildContext<TFactory> obj,
        Action<IJsonSchemaRootBuildContext<TFactory>> schemaConfig)
        where TFactory : IBuildContextFactory<TFactory>
    {
        var additional = TFactory.CreateRootBuildContext();
        schemaConfig.Invoke(additional);
        obj.AllowAdditionalPropertySchema = additional;
        return obj;
    }

    public static IJsonSchemaObjectBuildContext<TFactory> PatternProperty<TFactory>(
        this IJsonSchemaObjectBuildContext<TFactory> obj,
        [StringSyntax(StringSyntaxAttribute.Regex)]
        string regex,
        Action<IJsonSchemaRootBuildContext<TFactory>> schemaConfig)
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