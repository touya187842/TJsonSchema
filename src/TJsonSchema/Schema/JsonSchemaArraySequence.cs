using System.Collections.Generic;
using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaArraySequence : JsonSchemaBase<IJsonArray>, IJsonSchemaArray
{
    private readonly IReadOnlyList<IJsonSchema> Items;

    public JsonSchemaArraySequence(IReadOnlyList<IJsonSchema> items)
    {
        Items = items;
    }

    public override bool Validate(IJsonArray array)
    {
        if (array.Count > Items.Count)
        {
            return false;
        }

        for (var i = 0; i < Items.Count; i++)
        {
            if (Items[i].Validate(array[i]) is false)
            {
                return false;
            }
        }
        return true;
    }
}