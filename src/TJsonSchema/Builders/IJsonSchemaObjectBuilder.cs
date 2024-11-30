using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TJsonSchema.Builders;

public interface IJsonSchemaObjectBuilder : IJsonSchemaRootBuilder
{
    internal ICollection<IJsonSchemaPropertyBuilder>? Properties { get; set; }

    internal int? MinProperties { get; set; }

    internal int? MaxProperties { get; set; }

    internal IJsonSchemaRootBuilder? AllowAdditionalPropertySchema { get; set; }

    internal ICollection<KeyValuePair<Regex, IJsonSchemaRootBuilder>>? PatternProperties { get; set; }
}