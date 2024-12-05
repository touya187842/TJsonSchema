using System;

namespace TJsonSchema.Builders;

public static class JsonSchemaArrayBuildContextExtensions
{
    public static IJsonSchemaArrayBuildContext<TFactory> AsArray<TFactory>(
        this IJsonSchemaRootBuildContext<TFactory> context)
        where TFactory : IBuildContextFactory<TFactory>
    {
        switch (context)
        {
            case { Kind: null }:
            {
                var array = TFactory.CreateArrayBuildContext();
                context.Kind = array;
                return array;
            }
            case { Kind: IJsonSchemaArrayBuildContext<TFactory> array }:
            {
                return array;
            }
            default:
                throw new InvalidOperationException();
        }
    }

    public static IJsonSchemaArrayBuildContext<TFactory> MinItems<TFactory>(
        this IJsonSchemaArrayBuildContext<TFactory> array,
        int minItems)
        where TFactory : IBuildContextFactory<TFactory>
    {
        array.MinItems = minItems;
        return array;
    }

    public static IJsonSchemaArrayBuildContext<TFactory> MaxItems<TFactory>(
        this IJsonSchemaArrayBuildContext<TFactory> array,
        int maxItems)
        where TFactory : IBuildContextFactory<TFactory>
    {
        array.MaxItems = maxItems;
        return array;
    }

    public static IJsonSchemaArrayBuildContext<TFactory> UniqueItems<TFactory>(
        this IJsonSchemaArrayBuildContext<TFactory> array,
        bool mustUnique = true)
        where TFactory : IBuildContextFactory<TFactory>
    {
        array.MustUniqueItems = mustUnique;
        return array;
    }

    public static IJsonSchemaArrayBuildContext<TFactory> AdditionalItems<TFactory>(
        this IJsonSchemaArrayBuildContext<TFactory> array, bool allowAny)
        where TFactory : IBuildContextFactory<TFactory>
    {
        var root = TFactory.CreateRootBuildContext();
        root.Kind = allowAny ? AllowAnyJsonSchema.Instance : DisallowAnyJsonSchema.Instance;
        array.AllowAdditionalItemSchema = root;
        return array;
    }
}