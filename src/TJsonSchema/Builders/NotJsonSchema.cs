namespace TJsonSchema.Builders;

internal class NotJsonSchema<TFactory> : IJsonSchemaBuildContext
    where TFactory : IBuildContextFactory<TFactory>
{
    public string? Description { get; set; }

    public required IJsonSchemaRootBuildContext<TFactory> Schema { get; set; }
}