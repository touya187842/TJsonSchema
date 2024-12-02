namespace TJsonSchema.Builders;

public static class JsonSchemaArrayBuildContextExtensions
{
    public static T MinItems<T>(this T array, int minItems) where T : IJsonSchemaArrayBuildContext
    {
        array.MinItems = minItems;
        return array;
    }

    public static T MaxItems<T>(this T array, int maxItems) where T : IJsonSchemaArrayBuildContext
    {
        array.MaxItems = maxItems;
        return array;
    }

    public static T UniqueItems<T>(this T array, bool mustUnique = true) where T : IJsonSchemaArrayBuildContext
    {
        array.MustUniqueItems = mustUnique;
        return array;
    }

    public static T AdditionalItems<T>(this T array, bool allowAny) where T : IJsonSchemaArrayBuildContext
    {
        array.AllowAdditionalItemSchema = allowAny ? AllowAnyJsonSchema.Instance : DisallowAnyJsonSchema.Instance;
        return array;
    }
}