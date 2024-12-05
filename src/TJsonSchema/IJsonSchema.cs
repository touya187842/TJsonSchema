namespace TJsonSchema;

/// <summary>
/// 代表一個可以驗證 Json 格式的 JsonSchema
/// </summary>
public interface IJsonSchema
{
    /// <summary>
    /// 驗證 Json 是否符合 Schema
    /// </summary>
    /// <param name="node">Json 物件</param>
    /// <returns><see langword="true"/> 表示符合; <see langword="false"/> 表示不符合</returns>
    public bool Validate(IJsonNode node);
}

public interface IJsonSchema<in T> : IJsonSchema where T : IJsonNode
{
    public bool Validate(T value);
}