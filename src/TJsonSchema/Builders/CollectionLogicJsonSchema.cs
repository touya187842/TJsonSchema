using System.Collections.Generic;

namespace TJsonSchema.Builders;

internal abstract class CollectionLogicJsonSchema<TFactory> : IJsonSchemaBuildContext
    where TFactory : IBuildContextFactory<TFactory>
{
    public string? Description { get; set; }

    public ICollection<IJsonSchemaRootBuildContext<TFactory>> Items { get; set; } =
        new List<IJsonSchemaRootBuildContext<TFactory>>();
}

internal class AnyOfJsonSchema<TFactory> : CollectionLogicJsonSchema<TFactory>
    where TFactory : IBuildContextFactory<TFactory>
{
}

internal class AllOfJsonSchema<TFactory> : CollectionLogicJsonSchema<TFactory>
    where TFactory : IBuildContextFactory<TFactory>
{
}

internal class OneOfJsonSchema<TFactory> : CollectionLogicJsonSchema<TFactory>
    where TFactory : IBuildContextFactory<TFactory>
{
}