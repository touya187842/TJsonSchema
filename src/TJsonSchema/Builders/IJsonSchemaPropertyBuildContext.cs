using System.Collections.Generic;

namespace TJsonSchema.Builders;

/// <summary>
/// 表示一個關於 Property 的 JsonSchema 建造者, 包含 Property 名稱跟對應的 JsonSchema Property 值
/// </summary>
public interface IJsonSchemaPropertyBuildContext<TFactory>
    where TFactory : IBuildContextFactory<TFactory>
{
    /// <summary>
    /// Property 名稱
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Property 值, 代表一個 JsonSchema
    /// </summary>
    public IJsonSchemaRootBuildContext<TFactory> Property { get; set; }

    /// <summary>
    /// 這個 Property 存在前提所需的其他 Property
    /// </summary>
    internal ICollection<object>? Dependencies { get; set; }

    /// <summary>
    /// 這個 Property 是否為必要
    /// </summary>
    internal bool? IsRequired { get; set; }
}