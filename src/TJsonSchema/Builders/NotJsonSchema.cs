namespace TJsonSchema.Builders;

internal class NotJsonSchema : IJsonSchemaRootBuildContext
{
    public string? Description { get; set; }
    
    public required IJsonSchemaRootBuildContext Schema { get; set; }
}