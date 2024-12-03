namespace TJsonSchema.Builders;

/// <summary>
/// 表示任何 Json 物件皆不合格的 JsonSchema
/// </summary>
internal class DisallowAnyJsonSchema : IJsonSchemaBuildContext
{
    internal static DisallowAnyJsonSchema Instance { get; } = new DisallowAnyJsonSchema();

    public string? Description { get; set; }
}