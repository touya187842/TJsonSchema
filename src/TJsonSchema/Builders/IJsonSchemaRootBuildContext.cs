namespace TJsonSchema.Builders;

/// <summary>
/// 表示一個 JsonSchema 建造的起點
/// </summary>
public interface IJsonSchemaRootBuildContext
{
    /// <summary>
    /// 對此 JsonSchema 節點的描述
    /// </summary>
    internal string? Description { get; set; }
}