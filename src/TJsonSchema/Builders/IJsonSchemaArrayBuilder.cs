using System.Collections.Generic;

namespace TJsonSchema.Builders;

/// <summary>
/// 表示一個關於 陣列/集合 的 JsonSchema 建造者
/// </summary>
public interface IJsonSchemaArrayBuilder : IJsonSchemaRootBuilder
{
    /// <summary>
    /// 設定集合中最多可以允許的項目數
    /// </summary>
    internal int? MaxItems { get; set; }

    /// <summary>
    /// 設定集合中至少需要有的項目數
    /// </summary>
    internal int? MinItems { get; set; }

    /// <summary>
    /// 設定集合中的項目是否必須是唯一
    /// </summary>
    internal bool? MustUniqueItems { get; set; }

    /// <summary>
    /// 設定集合中的項目依照位置, 必須滿足的 JsonSchema
    /// </summary>
    internal ICollection<IJsonSchemaRootBuilder>? Items { get; set; }

    /// <summary>
    /// 設定集合中是否可以存在依位置定義之外的 JsonSchema
    /// </summary>
    internal IJsonSchemaRootBuilder? AllowAdditionalItemSchema { get; set; }
}