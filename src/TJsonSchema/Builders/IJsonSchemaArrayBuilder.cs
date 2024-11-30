using System.Collections.Generic;

namespace TJsonSchema.Builders;

public interface IJsonSchemaArrayBuilder : IJsonSchemaRootBuilder
{
    internal int? MaxItems { get; set; }

    internal int? MinItems { get; set; }

    internal bool? MustUniqueItems { get; set; }

    internal ICollection<IJsonSchemaRootBuilder>? Items { get; set; }

    internal IJsonSchemaRootBuilder? AllowAdditionalItemSchema { get; set; }
}