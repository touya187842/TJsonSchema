namespace TJsonSchema.Json;

public interface IJsonNumber : IJsonNode
{
    public double Value { get; }
}