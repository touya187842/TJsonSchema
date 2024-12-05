using System.Collections.Generic;
using System.Linq;
using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaArrayUniqueItems : JsonSchemaBase<IJsonArray>, IJsonSchemaArray
{
    public override bool Validate(IJsonArray value)
    {
        var @set = new HashSet<IJsonNode?>(JsonNodeComparer.Instance);
        return value.All(node => @set.Add(node));
    }
}