using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace TJsonSchema.Builders;

public static class JsonSchemaObjectBuildContextExtensions
{
    public static T MinProperties<T>(this T obj, int minProperties) where T : IJsonSchemaObjectBuildContext
    {
        obj.MinProperties = minProperties;
        return obj;
    }

    public static T MaxProperties<T>(this T obj, int maxProperties) where T : IJsonSchemaObjectBuildContext
    {
        obj.MaxProperties = maxProperties;
        return obj;
    }

    public static T AdditionalProperties<T>(this T obj, bool allowAny) where T : IJsonSchemaObjectBuildContext
    {
        obj.AllowAdditionalPropertySchema = allowAny ? AllowAnyJsonSchema.Instance : DisallowAnyJsonSchema.Instance;
        return obj;
    }

    public static IJsonSchemaPropertyBuildContext AddProperty<T>(
        this T obj,
        string propertyName,
        Action<IJsonSchemaRootBuildContext> propertyValue)
        where T : IJsonSchemaObjectBuildContext
    {
        if (obj.Properties is null)
        {
            obj.Properties  = new Dictionary<string, IJsonSchemaPropertyBuildContext>();
        }
        else
        {
            if (obj.Properties.ContainsKey(propertyName))
            {
                throw new ArgumentException($"Property {propertyName} is already added.");
            }
        }
        var template = new DefaultJsonSchemaBuildContext();
        propertyValue.Invoke(template);
        var property = new JsonSchemaPropertyBuildContext { Name = propertyName, Property = template };
        return property;
    }

    public static T AdditionalProperties<T>(this T obj, Action<IJsonSchemaRootBuildContext> schemaConfig)
        where T : IJsonSchemaObjectBuildContext
    {
        var additional = new DefaultJsonSchemaBuildContext();
        schemaConfig.Invoke(additional);
        obj.AllowAdditionalPropertySchema = additional;
        return obj;
    }

    public static T PatternProperty<T>(
        this T obj,
        [StringSyntax(StringSyntaxAttribute.Regex)]
        string regex,
        Action<IJsonSchemaRootBuildContext> schemaConfig)
        where T : IJsonSchemaObjectBuildContext
    {
        var additional = new DefaultJsonSchemaBuildContext();
        schemaConfig.Invoke(additional);
        obj.PatternProperties ??= new List<KeyValuePair<Regex, IJsonSchemaRootBuildContext>>();
        obj.PatternProperties.Add(new KeyValuePair<Regex, IJsonSchemaRootBuildContext>(new Regex(regex), additional));
        return obj;
    }
}