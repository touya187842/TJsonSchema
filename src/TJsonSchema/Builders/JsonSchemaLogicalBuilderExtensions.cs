using System;

namespace TJsonSchema.Builders;

public static class JsonSchemaLogicalBuilderExtensions
{
    public static T Not<T>(this T schema, Action<IJsonSchemaRootBuilder> subSchema)
        where T : IJsonSchemaRootBuilder
    {
        if (schema is DefaultJsonSchemaRootBuilder { Child: null } @default)
        {
            var template = new DefaultJsonSchemaRootBuilder();
            subSchema.Invoke(template);
            @default.Child = new NotJsonSchema { Schema = template };
            return schema;
        }
        throw new InvalidOperationException();
    }

    public static T AnyOf<T>(this T schema, params Action<IJsonSchemaRootBuilder>[] subSchemas)
        where T : IJsonSchemaRootBuilder
    {
        switch (schema)
        {
            case DefaultJsonSchemaRootBuilder { Child: null } @default:
            {
                @default.Child = new AnyOfJsonSchema().AddSubSchemas(subSchemas);
                return schema;
            }
            case DefaultJsonSchemaRootBuilder { Child: AnyOfJsonSchema anyOf } @default:
            {
                anyOf.AddSubSchemas(subSchemas);
                return schema;
            }
            case AnyOfJsonSchema anyOf:
            {
                anyOf.AddSubSchemas(subSchemas);
                return schema;
            }
            default:
                throw new InvalidOperationException();
        }
    }

    public static T AllOf<T>(this T schema, params Action<IJsonSchemaRootBuilder>[] subSchemas)
        where T : IJsonSchemaRootBuilder
    {
        switch (schema)
        {
            case DefaultJsonSchemaRootBuilder { Child: null } @default:
            {
                @default.Child = new AllOfJsonSchema().AddSubSchemas(subSchemas);
                return schema;
            }
            case DefaultJsonSchemaRootBuilder { Child: AllOfJsonSchema allOf } @default:
            {
                allOf.AddSubSchemas(subSchemas);
                return schema;
            }
            case AllOfJsonSchema allOf:
            {
                allOf.AddSubSchemas(subSchemas);
                return schema;
            }
            default:
                throw new InvalidOperationException();
        }
    }

    public static T OneOf<T>(this T schema, params Action<IJsonSchemaRootBuilder>[] subSchemas)
        where T : IJsonSchemaRootBuilder
    {
        switch (schema)
        {
            case DefaultJsonSchemaRootBuilder { Child: null } @default:
            {
                @default.Child = new OneOfJsonSchema().AddSubSchemas(subSchemas);
                return schema;
            }
            case DefaultJsonSchemaRootBuilder { Child: AnyOfJsonSchema oneOf } @default:
            {
                oneOf.AddSubSchemas(subSchemas);
                return schema;
            }
            case AnyOfJsonSchema oneOf:
            {
                oneOf.AddSubSchemas(subSchemas);
                return schema;
            }
            default:
                throw new InvalidOperationException();
        }
    }

    private static T AddSubSchemas<T>(this T collections, Action<IJsonSchemaRootBuilder>[] subSchemas)
        where T : CollectionLogicJsonSchema
    {
        foreach (var schema in subSchemas)
        {
            var subSchema = new DefaultJsonSchemaRootBuilder();
            schema.Invoke(subSchema);
            collections.Items.Add(subSchema);
        }

        return collections;
    }
}