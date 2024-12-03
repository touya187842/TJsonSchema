using System;

namespace TJsonSchema.Builders;

public static class JsonSchemaLogicalBuildContextExtensions
{
    public static T Not<T>(this T schema, Action<IJsonSchemaBuildContext> subSchema)
        where T : IJsonSchemaBuildContext
    {
        if (schema is IJsonSchemaRootBuildContext { Kind: null } @default)
        {
            var template = new DefaultJsonSchemaBuildContext();
            subSchema.Invoke(template);
            @default.Kind = new NotJsonSchema { Schema = template };
            return schema;
        }
        throw new InvalidOperationException();
    }

    public static T AnyOf<T>(this T schema, params Action<IJsonSchemaBuildContext>[] subSchemas)
        where T : IJsonSchemaBuildContext
    {
        switch (schema)
        {
            case IJsonSchemaRootBuildContext { Kind: null } @default:
            {
                @default.Kind = new AnyOfJsonSchema().AddSubSchemas(subSchemas);
                return schema;
            }
            case IJsonSchemaRootBuildContext { Kind: AnyOfJsonSchema anyOf } @default:
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

    public static T AllOf<T>(this T schema, params Action<IJsonSchemaBuildContext>[] subSchemas)
        where T : IJsonSchemaBuildContext
    {
        switch (schema)
        {
            case IJsonSchemaRootBuildContext { Kind: null } @default:
            {
                @default.Kind = new AllOfJsonSchema().AddSubSchemas(subSchemas);
                return schema;
            }
            case IJsonSchemaRootBuildContext { Kind: AllOfJsonSchema allOf } @default:
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

    public static T OneOf<T>(this T schema, params Action<IJsonSchemaBuildContext>[] subSchemas)
        where T : IJsonSchemaBuildContext
    {
        switch (schema)
        {
            case IJsonSchemaRootBuildContext { Kind: null } @default:
            {
                @default.Kind = new OneOfJsonSchema().AddSubSchemas(subSchemas);
                return schema;
            }
            case IJsonSchemaRootBuildContext { Kind: AnyOfJsonSchema oneOf } @default:
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

    private static T AddSubSchemas<T>(this T collections, Action<IJsonSchemaBuildContext>[] subSchemas)
        where T : CollectionLogicJsonSchema
    {
        foreach (var schema in subSchemas)
        {
            var subSchema = new DefaultJsonSchemaBuildContext();
            schema.Invoke(subSchema);
            collections.Items.Add(subSchema);
        }

        return collections;
    }
}