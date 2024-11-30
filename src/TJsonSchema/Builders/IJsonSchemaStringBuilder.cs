using System.Text.RegularExpressions;

namespace TJsonSchema.Builders;

public interface IJsonSchemaStringBuilder : IJsonSchemaRootBuilder
{
    internal JsonSchemaStringFormat? Format { get; set; }

    internal Regex? Pattern { get; set; }

    internal int? MinLength { get; set; }

    internal int? MaxLength { get; set; }
}