using System.Collections.Generic;
using System.Linq;

namespace TJsonSchema.Schema;

internal class JsonSchemaAggregate<T> : JsonSchemaBase<T> where T : IJsonNode
{
    private readonly IEnumerable<IJsonSchema<T>> Schemas;

    protected internal JsonSchemaAggregate(IEnumerable<IJsonSchema<T>> schemas)
    {
        Schemas = schemas;
    }

    public override bool Validate(T value)=> Schemas.All(schema => schema.Validate(value));
}