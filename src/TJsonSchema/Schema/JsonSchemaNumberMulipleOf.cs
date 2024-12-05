using TJsonSchema.Json;

namespace TJsonSchema.Schema;

internal class JsonSchemaNumberMulipleOf : JsonSchemaBase<IJsonNumber>, IJsonSchemaNumber
{
    private readonly int MulipleOf;

    public JsonSchemaNumberMulipleOf(int multipleOf)
    {
        MulipleOf = multipleOf;
    }

    public override bool Validate(IJsonNumber number)
    {
        return number.Value % MulipleOf == 0;
    }
}