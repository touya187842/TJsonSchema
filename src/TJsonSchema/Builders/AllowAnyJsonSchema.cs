namespace TJsonSchema.Builders;

internal class AllowAnyJsonSchema : IJsonSchema, IJsonSchemaRootBuilder
{
    internal static AllowAnyJsonSchema Instance { get; } = new AllowAnyJsonSchema();

    public string? Description { get; set; }

    public IJsonSchema Build() => this;
    
    public bool Validate(IJsonNode root) => true;
}