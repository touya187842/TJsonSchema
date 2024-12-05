using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaStringMaxLength : JsonSchemaBase<IJsonString>, IJsonSchemaString
{
    private readonly int MaxLength;

    public JsonSchemaStringMaxLength(int maxLength)
    {
        MaxLength = maxLength;
    }

    public override bool Validate(IJsonString text)
    {
        return text.Value.Length <= MaxLength;
    }
}