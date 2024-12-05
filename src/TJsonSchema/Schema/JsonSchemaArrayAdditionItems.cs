using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaArrayAdditionItems : JsonSchemaBase<IJsonArray>, IJsonSchemaArray
{
    private readonly IJsonSchema Addition;
    private readonly int From;

    public JsonSchemaArrayAdditionItems(IJsonSchema addition, int from)
    {
        Addition = addition;
        From = from;
    }

    public override bool Validate(IJsonArray array)
    {
        for (var i = From; i < array.Count; i++)
        {
            if (Addition.Validate(array[i]) is false)
            {
                return false;
            }
        }
        return true;
    }
}