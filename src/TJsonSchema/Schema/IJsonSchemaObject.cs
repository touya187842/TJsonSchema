using System.Collections.Generic;

namespace TJsonSchema.Schema;

public interface IJsonSchemaObject : IJsonSchema
{
    public bool Validate(KeyValuePair<string, IJsonNode> property);
}