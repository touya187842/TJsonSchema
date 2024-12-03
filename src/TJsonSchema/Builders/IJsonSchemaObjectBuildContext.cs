using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TJsonSchema.Builders;

/// <summary>
/// 表示一個關於 Object 的 JsonSchema 建造者
/// </summary>
public interface IJsonSchemaObjectBuildContext : IJsonSchemaBuildContext
{
    /// <summary>
    /// 這個 Object 定義的 Properties
    /// </summary>
    internal IDictionary<string, IJsonSchemaPropertyBuildContext>? Properties { get; set; }

    /// <summary>
    /// 這個 Object 至少需要含有多少 Properties
    /// </summary>
    internal int? MinProperties { get; set; }

    /// <summary>
    /// 這個 Object 最多只能包含多少 Properties
    /// </summary>
    internal int? MaxProperties { get; set; }

    /// <summary>
    /// 設定這個 Objects 能否在定義之外增加其他的 Properties
    /// </summary>
    internal IJsonSchemaBuildContext? AllowAdditionalPropertySchema { get; set; }

    /// <summary>
    /// 設定這個 Objects 檢查符合 Regex 定義的 Property 名稱, 對應的 Property 值需要符合的 JsonSchema 
    /// </summary>
    internal ICollection<KeyValuePair<Regex, IJsonSchemaBuildContext>>? PatternProperties { get; set; }
}