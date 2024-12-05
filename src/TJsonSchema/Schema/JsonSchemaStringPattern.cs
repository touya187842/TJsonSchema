using System.Text.RegularExpressions;
using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaStringPattern : JsonSchemaBase<IJsonString>, IJsonSchemaString
{
    private readonly Regex Pattern;

    public JsonSchemaStringPattern(Regex pattern)
    {
        Pattern = pattern;
    }

    public override bool Validate(IJsonString text)
    {
        return Pattern.IsMatch(text.Value);
    }
}