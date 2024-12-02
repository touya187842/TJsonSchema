using System;

namespace TJsonSchema.Builders;

public static class JsonSchemaLogicalBuildContextExtensions
{
    public static T Not<T>(this T schema, Action<IJsonSchemaRootBuildContext> subSchema)
        where T : IJsonSchemaRootBuildContext
    {
        if (schema is IJsonSchemaUnkindBuildContext { Kind: null } @default)
        {
            var template = new DefaultJsonSchemaBuildContext();
            subSchema.Invoke(template);
            @default.Kind = new NotJsonSchema { Schema = template };
            return schema;
        }
        throw new InvalidOperationException();
    }

    public static T AnyOf<T>(this T schema, params Action<IJsonSchemaRootBuildContext>[] subSchemas)
        where T : IJsonSchemaRootBuildContext
    {
        switch (schema)
        {
            case IJsonSchemaUnkindBuildContext { Kind: null } @default:
            {
                @default.Kind = new AnyOfJsonSchema().AddSubSchemas(subSchemas);
                return schema;
            }
            case IJsonSchemaUnkindBuildContext { Kind: AnyOfJsonSchema anyOf } @default:
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

    public static T AllOf<T>(this T schema, params Action<IJsonSchemaRootBuildContext>[] subSchemas)
        where T : IJsonSchemaRootBuildContext
    {
        switch (schema)
        {
            case IJsonSchemaUnkindBuildContext { Kind: null } @default:
            {
                @default.Kind = new AllOfJsonSchema().AddSubSchemas(subSchemas);
                return schema;
            }
            case IJsonSchemaUnkindBuildContext { Kind: AllOfJsonSchema allOf } @default:
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

    public static T OneOf<T>(this T schema, params Action<IJsonSchemaRootBuildContext>[] subSchemas)
        where T : IJsonSchemaRootBuildContext
    {
        switch (schema)
        {
            case IJsonSchemaUnkindBuildContext { Kind: null } @default:
            {
                @default.Kind = new OneOfJsonSchema().AddSubSchemas(subSchemas);
                return schema;
            }
            case IJsonSchemaUnkindBuildContext { Kind: AnyOfJsonSchema oneOf } @default:
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

    private static T AddSubSchemas<T>(this T collections, Action<IJsonSchemaRootBuildContext>[] subSchemas)
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