namespace TJsonSchema.Builders;

/// <summary>
/// 表示任何 Json 物件皆合格的 JsonSchema
/// </summary>
internal class AllowAnyJsonSchema : IJsonSchemaRootBuilder
{
    internal static AllowAnyJsonSchema Instance { get; } = new AllowAnyJsonSchema();

    public string? Description { get; set; }
}