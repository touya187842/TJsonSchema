using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaStringFormat : JsonSchemaBase<IJsonString>, IJsonSchemaString
{
    private readonly TJsonSchema.Builders.JsonSchemaStringFormat Format;

    public JsonSchemaStringFormat(TJsonSchema.Builders.JsonSchemaStringFormat format)
    {
        Format = format;
    }

    public override bool Validate(IJsonString text)
    {
        return Format.Validate(text.Value);
    }
}