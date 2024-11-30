namespace TJsonSchema.Builders;

/// <summary>
/// 表示用於 JsonSchema 中定義的字串格式
/// </summary>
public abstract class JsonSchemaStringFormat
{
    /// <summary>
    /// 字串格式名稱
    /// </summary>
    public virtual required string Name { get; init; }
    
    /// <summary>
    /// 驗證字串是否符合格式
    /// </summary>
    /// <param name="text">被驗證的字串</param>
    /// <returns><see langword="true"/> 表示符合; <see langword="false"/> 表示不符合</returns>
    public abstract bool Validate(string text);
}