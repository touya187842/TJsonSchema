using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaStringMinLength : JsonSchemaBase<IJsonString>, IJsonSchemaString
{
    private readonly int MinLength;

    public JsonSchemaStringMinLength(int minLength)
    {
        MinLength = minLength;
    }

    public override bool Validate(IJsonString text)
    {
        return text.Value.Length >= MinLength;
    }
}