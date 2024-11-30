namespace TJsonSchema.Schema;

internal interface IJsonSchemaNumber : IJsonSchema
{
    public bool Validate(double number);
}