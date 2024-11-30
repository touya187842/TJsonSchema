namespace TJsonSchema.Builders;

public static class JsonSchemaNumberBuilderExtensions
{
    public static T MustBeMultipleOf<T>(this T number, int multipleOf) where T : IJsonSchemaNumberBuilder
    {
        number.MultipleOf = multipleOf;
        return number;
    }

    public static T LessThen<T>(this T number, double lessThen) where T : IJsonSchemaNumberBuilder
    {
        number.LessThan = lessThen;
        return number;
    }

    public static T LessThenOrEqualTo<T>(this T number, double lessEqual) where T : IJsonSchemaNumberBuilder
    {
        number.LessEqual = lessEqual;
        return number;
    }

    public static T GreaterThen<T>(this T number, double greaterThen) where T : IJsonSchemaNumberBuilder
    {
        number.GreaterThan = greaterThen;
        return number;
    }

    public static T GreaterThenOrEqualTo<T>(this T number, double greaterEqual) where T : IJsonSchemaNumberBuilder
    {
        number.GreaterEqual = greaterEqual;
        return number;
    }
}