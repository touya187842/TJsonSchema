namespace TJsonSchema.Schema;

internal abstract class JsonSchemaBase<T> : IJsonSchema<T> where T : IJsonNode
{
    public bool Validate(IJsonNode? node)
    {
        return node is T typed && Validate(typed);
    }

    public abstract bool Validate(T value);
}