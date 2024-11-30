using System.Text.RegularExpressions;

namespace TJsonSchema.Builders;

/// <summary>
/// 表示一個關於 字串 的 JsonSchema 建造者
/// </summary>
public interface IJsonSchemaStringBuilder : IJsonSchemaRootBuilder
{
    /// <summary>
    /// 設定字串須符合已知的 format
    /// </summary>
    internal JsonSchemaStringFormat? Format { get; set; }

    /// <summary>
    /// 設定字串須符合 Regex
    /// </summary>
    internal Regex? Pattern { get; set; }

    /// <summary>
    /// 設定字串的最小長度
    /// </summary>
    internal int? MinLength { get; set; }

    /// <summary>
    /// 設定字串的最大長度
    /// </summary>
    internal int? MaxLength { get; set; }
}