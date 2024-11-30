using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace TJsonSchema.Builders;

public static class JsonSchemaObjectBuilderExtensions
{
    public static T MinProperties<T>(this T obj, int minProperties) where T : IJsonSchemaObjectBuilder
    {
        obj.MinProperties = minProperties;
        return obj;
    }

    public static T MaxProperties<T>(this T obj, int maxProperties) where T : IJsonSchemaObjectBuilder
    {
        obj.MaxProperties = maxProperties;
        return obj;
    }

    public static T AdditionalProperties<T>(this T obj, bool allowAny) where T : IJsonSchemaObjectBuilder
    {
        obj.AllowAdditionalPropertySchema = allowAny ? AllowAnyJsonSchema.Instance : DisallowAnyJsonSchema.Instance;
        return obj;
    }

    public static IJsonSchemaPropertyBuilder AddProperty<T>(
        this T obj,
        string propertyName,
        Action<IJsonSchemaRootBuilder> propertyValue)
        where T : IJsonSchemaObjectBuilder
    {
        if (obj.Properties is null)
        {
            obj.Properties  = new Dictionary<string, IJsonSchemaPropertyBuilder>();
        }
        else
        {
            if (obj.Properties.ContainsKey(propertyName))
            {
                throw new ArgumentException($"Property {propertyName} is already added.");
            }
        }
        var template = new DefaultJsonSchemaRootBuilder();
        propertyValue.Invoke(template);
        var property = new JsonSchemaPropertyBuilder { Name = propertyName, Property = template };
        return property;
    }

    public static T AdditionalProperties<T>(this T obj, Action<IJsonSchemaRootBuilder> schemaConfig)
        where T : IJsonSchemaObjectBuilder
    {
        var additional = new DefaultJsonSchemaRootBuilder();
        schemaConfig.Invoke(additional);
        obj.AllowAdditionalPropertySchema = additional;
        return obj;
    }

    public static T PatternProperty<T>(
        this T obj,
        [StringSyntax(StringSyntaxAttribute.Regex)]
        string regex,
        Action<IJsonSchemaRootBuilder> schemaConfig)
        where T : IJsonSchemaObjectBuilder
    {
        var additional = new DefaultJsonSchemaRootBuilder();
        schemaConfig.Invoke(additional);
        obj.PatternProperties ??= new List<KeyValuePair<Regex, IJsonSchemaRootBuilder>>();
        obj.PatternProperties.Add(new KeyValuePair<Regex, IJsonSchemaRootBuilder>(new Regex(regex), additional));
        return obj;
    }
}