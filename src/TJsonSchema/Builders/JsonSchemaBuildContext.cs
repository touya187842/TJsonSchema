namespace TJsonSchema.Builders;

public class JsonSchemaBuildContext<TFactory> : JsonSchemaRootBuildContextBase<TFactory>
    where TFactory : IBuildContextFactory<TFactory>
{
    internal string? ID { get; set; }

    internal string? Title { get; set; }
}