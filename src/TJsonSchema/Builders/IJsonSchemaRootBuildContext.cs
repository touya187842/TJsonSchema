namespace TJsonSchema.Builders;

internal interface IJsonSchemaRootBuildContext : IJsonSchemaBuildContext
{
    internal IJsonSchemaBuildContext? Kind { get; set; }
}