using System.Text.RegularExpressions;

namespace TJsonSchema.Builders;

internal abstract class JsonSchemaStringBuildContextBase<T> 
    : IJsonSchemaStringBuildContext
    where T : IBuildContextFactory<T>
{
    public string? Description { get; set; }
    public JsonSchemaStringFormat? Format { get; set; }
    public Regex? Pattern { get; set; }
    public int? MinLength { get; set; }
    public int? MaxLength { get; set; }
}