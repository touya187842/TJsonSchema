namespace TJsonSchema.Builders;

internal class NotJsonSchema : IJsonSchemaRootBuilder
{
    public string? Description { get; set; }
    
    public required IJsonSchemaRootBuilder Schema { get; set; }
}