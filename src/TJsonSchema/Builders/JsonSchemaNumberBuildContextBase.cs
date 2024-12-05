namespace TJsonSchema.Builders;

internal abstract class JsonSchemaNumberBuildContextBase<T> 
    : IJsonSchemaNumberBuildContext
    where T : IBuildContextFactory<T>
{
    public string? Description { get; set; }
    public int? MultipleOf { get; set; }
    public double? LessThan { get; set; }
    public double? LessEqual { get; set; }
    public double? GreaterThan { get; set; }
    public double? GreaterEqual { get; set; }
}