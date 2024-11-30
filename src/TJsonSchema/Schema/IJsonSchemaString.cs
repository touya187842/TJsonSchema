namespace TJsonSchema.Schema;

public interface IJsonSchemaString : IJsonSchema
{
    public bool Validate(string text);
}