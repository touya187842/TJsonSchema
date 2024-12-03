namespace TJsonSchema.Builders;

internal class NotJsonSchema : IJsonSchemaBuildContext
{
    public string? Description { get; set; }
    
    public required IJsonSchemaBuildContext Schema { get; set; }
}