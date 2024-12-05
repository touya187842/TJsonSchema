using System;

namespace TJsonSchema.Builders;

public static class JsonSchemaLogicalBuildContextExtensions
{
    public static IJsonSchemaRootBuildContext<TFactory> Not<TFactory>(this IJsonSchemaRootBuildContext<TFactory> schema,
        Action<IJsonSchemaRootBuildContext<TFactory>> subSchema)
        where TFactory : IBuildContextFactory<TFactory>
    {
        if (schema is IJsonSchemaRootBuildContext<TFactory> { Kind: null } @default)
        {
            var template = TFactory.CreateRootBuildContext();
            subSchema.Invoke(template);
            @default.Kind = new NotJsonSchema<TFactory> { Schema = template };
            return schema;
        }

        throw new InvalidOperationException();
    }

    public static IJsonSchemaRootBuildContext<TFactory> AnyOf<TFactory>(
        this IJsonSchemaRootBuildContext<TFactory> schema,
        params Action<IJsonSchemaRootBuildContext<TFactory>>[] subSchemas)
        where TFactory : IBuildContextFactory<TFactory>
    {
        switch (schema)
        {
            case IJsonSchemaRootBuildContext<TFactory> { Kind: null } @default:
            {
                @default.Kind = new AnyOfJsonSchema<TFactory>().AddSubSchemas(subSchemas);
                return schema;
            }
            case IJsonSchemaRootBuildContext<TFactory> { Kind: AnyOfJsonSchema<TFactory> anyOf } @default:
            {
                anyOf.AddSubSchemas(subSchemas);
                return schema;
            }
            default:
                throw new InvalidOperationException();
        }
    }

    public static IJsonSchemaRootBuildContext<TFactory> AllOf<TFactory>(
        this IJsonSchemaRootBuildContext<TFactory> schema,
        params Action<IJsonSchemaRootBuildContext<TFactory>>[] subSchemas)
        where TFactory : IBuildContextFactory<TFactory>
    {
        switch (schema)
        {
            case IJsonSchemaRootBuildContext<TFactory> { Kind: null } @default:
            {
                @default.Kind = new AllOfJsonSchema<TFactory>().AddSubSchemas(subSchemas);
                return schema;
            }
            case IJsonSchemaRootBuildContext<TFactory> { Kind: AllOfJsonSchema<TFactory> allOf } @default:
            {
                allOf.AddSubSchemas(subSchemas);
                return schema;
            }
            default:
                throw new InvalidOperationException();
        }
    }

    public static IJsonSchemaRootBuildContext<TFactory> OneOf<TFactory>(
        this IJsonSchemaRootBuildContext<TFactory> schema,
        params Action<IJsonSchemaRootBuildContext<TFactory>>[] subSchemas)
        where TFactory : IBuildContextFactory<TFactory>
    {
        switch (schema)
        {
            case IJsonSchemaRootBuildContext<TFactory> { Kind: null } @default:
            {
                @default.Kind = new OneOfJsonSchema<TFactory>().AddSubSchemas(subSchemas);
                return schema;
            }
            case IJsonSchemaRootBuildContext<TFactory> { Kind: AnyOfJsonSchema<TFactory> oneOf } @default:
            {
                oneOf.AddSubSchemas(subSchemas);
                return schema;
            }
            default:
                throw new InvalidOperationException();
        }
    }

    private static TCollectionLogicJsonSchema AddSubSchemas<TCollectionLogicJsonSchema, TFactory>(
        this TCollectionLogicJsonSchema collections,
        Action<IJsonSchemaRootBuildContext<TFactory>>[] subSchemas)
        where TCollectionLogicJsonSchema : CollectionLogicJsonSchema<TFactory>
        where TFactory : IBuildContextFactory<TFactory>
    {
        foreach (var schema in subSchemas)
        {
            var subSchema = TFactory.CreateRootBuildContext();
            schema.Invoke(subSchema);
            collections.Items.Add(subSchema);
        }

        return collections;
    }
}