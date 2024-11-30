using System.Collections.Generic;

namespace TJsonSchema.Builders;

internal abstract class CollectionLogicJsonSchema : IJsonSchemaRootBuilder
{
    public string? Description { get; set; }

    public ICollection<IJsonSchemaRootBuilder> Items { get; set; } = new List<IJsonSchemaRootBuilder>();
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