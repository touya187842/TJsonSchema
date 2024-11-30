namespace TJsonSchema.Builders;

internal class AllowAnyJsonSchema : IJsonSchemaRootBuilder
{
    internal static AllowAnyJsonSchema Instance { get; } = new AllowAnyJsonSchema();

    public string? Description { get; set; }
}