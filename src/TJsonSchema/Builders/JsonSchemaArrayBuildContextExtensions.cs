namespace TJsonSchema.Builders;

public static class JsonSchemaArrayBuildContextExtensions
{
    public static TContext MinItems<TContext, TFactory>(this TContext array, int minItems)
        where TContext : IJsonSchemaArrayBuildContext<TFactory>
        where TFactory : IBuildContextFactory<TFactory>
    {
        array.MinItems = minItems;
        return array;
    }

    public static TContext MaxItems<TContext, TFactory>(this TContext array, int maxItems)
        where TContext : IJsonSchemaArrayBuildContext<TFactory>
        where TFactory : IBuildContextFactory<TFactory>
    {
        array.MaxItems = maxItems;
        return array;
    }

    public static TContext UniqueItems<TContext, TFactory>(this TContext array, bool mustUnique = true)
        where TContext : IJsonSchemaArrayBuildContext<TFactory>
        where TFactory : IBuildContextFactory<TFactory>
    {
        array.MustUniqueItems = mustUnique;
        return array;
    }

    public static TContext AdditionalItems<TContext, TFactory>(this TContext array, bool allowAny)
        where TContext : IJsonSchemaArrayBuildContext<TFactory>
        where TFactory : IBuildContextFactory<TFactory>
    {
        var root = TFactory.CreateRootBuildContext();
        root.Kind = allowAny ? AllowAnyJsonSchema.Instance : DisallowAnyJsonSchema.Instance;
        array.AllowAdditionalItemSchema = root;
        return array;
    }
}