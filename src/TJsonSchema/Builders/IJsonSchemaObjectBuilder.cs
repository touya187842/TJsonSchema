using System.Collections.Generic;

namespace TJsonSchema.Builders;

public interface IJsonSchemaObjectBuilder : IJsonSchemaRootBuilder
{
    internal ICollection<IJsonSchemaPropertyBuilder>? Properties { get; set; }
}