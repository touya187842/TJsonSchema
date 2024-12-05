namespace TJsonSchema.Builders;

public static class JsonSchemaBuilderExtensions
{
    public static JsonSchemaBuildContext<TFactory> ID<TFactory>(
        this JsonSchemaBuildContext<TFactory> context,
        string id)
        where TFactory : IBuildContextFactory<TFactory>
    {
        context.ID = id;
        return context;
    }

    public static JsonSchemaBuildContext<TFactory> Title<TFactory>(
        this JsonSchemaBuildContext<TFactory> context,
        string title)
        where TFactory : IBuildContextFactory<TFactory>
    {
        context.Title = title;
        return context;
    }
}