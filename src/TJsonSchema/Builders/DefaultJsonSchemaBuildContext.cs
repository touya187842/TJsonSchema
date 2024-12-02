namespace TJsonSchema.Builders;

internal class DefaultJsonSchemaBuildContext : IJsonSchemaUnkindBuildContext
{
    public string? Description { get; set; }
    
    public IJsonSchemaRootBuildContext? Kind { get; set; }
}