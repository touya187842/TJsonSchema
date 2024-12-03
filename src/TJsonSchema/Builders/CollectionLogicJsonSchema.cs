using System.Collections.Generic;

namespace TJsonSchema.Builders;

internal abstract class CollectionLogicJsonSchema : IJsonSchemaBuildContext
{
    public string? Description { get; set; }

    public ICollection<IJsonSchemaBuildContext> Items { get; set; } = new List<IJsonSchemaBuildContext>();
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