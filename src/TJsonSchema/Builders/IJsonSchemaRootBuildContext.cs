namespace TJsonSchema.Builders;

public interface IJsonSchemaRootBuildContext<in T> where T : IBuildContextFactory<T>
{
    internal IJsonSchemaBuildContext? Kind { get; set; }

    public IJsonSchema Build();
}