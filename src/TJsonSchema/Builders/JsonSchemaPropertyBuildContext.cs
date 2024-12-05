using System.Collections.Generic;

namespace TJsonSchema.Builders;

internal class JsonSchemaPropertyBuildContext<TFactory> : IJsonSchemaPropertyBuildContext<TFactory>
    where TFactory : IBuildContextFactory<TFactory>
{
    public required string Name { get; set; }

    public required IJsonSchemaRootBuildContext<TFactory> Property { get; set; }

    public ICollection<object>? Dependencies { get; set; }

    public bool? IsRequired { get; set; }
}