namespace TJsonSchema.Builders;

public abstract class JsonSchemaStringFormat
{
    public virtual required string Name { get; init; }
    
    public abstract bool Validate(string text);
}