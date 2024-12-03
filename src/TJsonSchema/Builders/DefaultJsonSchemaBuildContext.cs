namespace TJsonSchema.Builders;

internal class DefaultJsonSchemaBuildContext : IJsonSchemaRootBuildContext
{
    public string? Description { get; set; }
    
    public IJsonSchemaBuildContext? Kind { get; set; }
}