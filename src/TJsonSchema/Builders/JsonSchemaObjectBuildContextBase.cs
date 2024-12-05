using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TJsonSchema.Builders;

internal abstract class JsonSchemaObjectBuildContextBase<T> 
    : IJsonSchemaObjectBuildContext<T>
    where T : IBuildContextFactory<T>
{
    public string? Description { get; set; }
    public IDictionary<string, IJsonSchemaPropertyBuildContext<T>>? Properties { get; set; }
    public int? MinProperties { get; set; }
    public int? MaxProperties { get; set; }
    public IJsonSchemaRootBuildContext<T>? AllowAdditionalPropertySchema { get; set; }
    public ICollection<KeyValuePair<Regex, IJsonSchemaRootBuildContext<T>>>? PatternProperties { get; set; }
}