using System.Collections.Generic;

namespace TJsonSchema.Builders;

internal abstract class JsonSchemaArrayBuildContextBase<T> 
    : IJsonSchemaArrayBuildContext<T>
    where T : IBuildContextFactory<T>
{
    public string? Description { get; set; }
    public int? MaxItems { get; set; }
    public int? MinItems { get; set; }
    public bool? MustUniqueItems { get; set; }
    public ICollection<IJsonSchemaRootBuildContext<T>>? Items { get; set; }
    public IJsonSchemaRootBuildContext<T>? AllowAdditionalItemSchema { get; set; }
}