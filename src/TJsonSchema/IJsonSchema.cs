namespace TJsonSchema;

public interface IJsonSchema
{
    public bool Validate(IJsonNode root);
}
