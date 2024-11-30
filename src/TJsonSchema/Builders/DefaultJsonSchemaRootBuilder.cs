namespace TJsonSchema.Builders;

public class DefaultJsonSchemaRootBuilder : IJsonSchemaRootBuilder
{
    public string? Description { get; set; }

    internal IJsonSchemaRootBuilder? Child { get; set; }
}