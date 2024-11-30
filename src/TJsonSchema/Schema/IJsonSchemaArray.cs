using System.Collections.Generic;

namespace TJsonSchema.Schema;

internal interface IJsonSchemaArray : IJsonSchema
{
    public bool Validate(IReadOnlyList<IJsonNode> array);
}