namespace TJsonSchema.Builders;

internal class DefaultJsonSchemaBuilder : IJsonSchemaUnkindBuilder
{
    public string? Description { get; set; }
    
    public IJsonSchemaRootBuilder? Kind { get; set; }
}