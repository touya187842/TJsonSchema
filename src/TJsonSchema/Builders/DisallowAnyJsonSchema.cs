namespace TJsonSchema.Builders;

internal class DisallowAnyJsonSchema : IJsonSchemaRootBuilder
{
    internal static DisallowAnyJsonSchema Instance { get; } = new DisallowAnyJsonSchema();

    public string? Description { get; set; }
}