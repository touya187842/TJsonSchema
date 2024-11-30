namespace TJsonSchema.Builders;

public interface IJsonSchemaNumberBuilder : IJsonSchemaRootBuilder
{
    internal int? MultipleOf { get; set; }

    internal double? LessThan { get; set; }

    internal double? LessEqual { get; set; }

    internal double? GreaterThan { get; set; }

    internal double? GreaterEqual { get; set; }
}