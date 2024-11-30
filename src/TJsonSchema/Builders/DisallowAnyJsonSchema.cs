namespace TJsonSchema.Builders;

internal class DisallowAnyJsonSchema : IJsonSchema, IJsonSchemaRootBuilder
{
    internal static DisallowAnyJsonSchema Instance { get; } = new DisallowAnyJsonSchema();

    public string? Description { get; set; }

    public IJsonSchema Build() => this;

    public bool Validate(IJsonNode root) => false;
}