using System.Collections.Generic;

namespace TJsonSchema.Builders;

internal abstract class CollectionLogicJsonSchema : IJsonSchemaRootBuildContext
{
    public string? Description { get; set; }

    public ICollection<IJsonSchemaRootBuildContext> Items { get; set; } = new List<IJsonSchemaRootBuildContext>();
}

internal class AnyOfJsonSchema : CollectionLogicJsonSchema
{
}

internal class AllOfJsonSchema : CollectionLogicJsonSchema
{
}

internal class OneOfJsonSchema : CollectionLogicJsonSchema
{
}