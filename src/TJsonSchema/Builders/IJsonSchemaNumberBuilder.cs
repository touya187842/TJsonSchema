namespace TJsonSchema.Builders;

/// <summary>
/// 表示一個關於 數值 的 JsonSchema 建造者
/// </summary>
public interface IJsonSchemaNumberBuilder : IJsonSchemaRootBuilder
{
    /// <summary>
    /// 設定數值必須是設定值的整數倍
    /// </summary>
    internal int? MultipleOf { get; set; }

    /// <summary>
    /// 設定數值必須嚴格小於設定值
    /// </summary>
    internal double? LessThan { get; set; }

    /// <summary>
    /// 設定數值必須小於或等於設定值
    /// </summary>
    internal double? LessEqual { get; set; }

    /// <summary>
    /// 設定數值必須嚴格大於設定值
    /// </summary>
    internal double? GreaterThan { get; set; }

    /// <summary>
    /// 設定數值必須大於或等於設定值
    /// </summary>
    internal double? GreaterEqual { get; set; }
}