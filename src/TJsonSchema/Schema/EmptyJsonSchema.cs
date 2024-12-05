namespace TJsonSchema.Schema;

internal class EmptyJsonSchema : IJsonSchema
{
    internal static EmptyJsonSchema Instance { get; } = new EmptyJsonSchema();

    public bool Validate(IJsonNode? node) => true;
}

internal class EmptyJsonSchema<T> : JsonSchemaBase<T>, IJsonSchema<T> where T : IJsonNode
{
    internal static EmptyJsonSchema<T> Instance { get; } = new EmptyJsonSchema<T>();

    public override bool Validate(T node) => true;
}