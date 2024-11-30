namespace TJsonSchema.Builders;

public static class JsonSchemaArrayBuilderExtensions
{
    public static T MinItems<T>(this T array, int minItems) where T : IJsonSchemaArrayBuilder
    {
        array.MinItems = minItems;
        return array;
    }

    public static T MaxItems<T>(this T array, int maxItems) where T : IJsonSchemaArrayBuilder
    {
        array.MaxItems = maxItems;
        return array;
    }

    public static T UniqueItems<T>(this T array, bool mustUnique = true) where T : IJsonSchemaArrayBuilder
    {
        array.MustUniqueItems = mustUnique;
        return array;
    }

    public static T AdditionalItems<T>(this T array, bool allowAny) where T : IJsonSchemaArrayBuilder
    {
        array.AllowAdditionalItemSchema = allowAny ? AllowAnyJsonSchema.Instance : DisallowAnyJsonSchema.Instance;
        return array;
    }
}