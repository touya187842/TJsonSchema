namespace TJsonSchema.Builders;

public static class JsonSchemaNumberBuildContextExtensions
{
    public static T MustBeMultipleOf<T>(this T number, int multipleOf) where T : IJsonSchemaNumberBuildContext
    {
        number.MultipleOf = multipleOf;
        return number;
    }

    public static T LessThen<T>(this T number, double lessThen) where T : IJsonSchemaNumberBuildContext
    {
        number.LessThan = lessThen;
        return number;
    }

    public static T LessThenOrEqualTo<T>(this T number, double lessEqual) where T : IJsonSchemaNumberBuildContext
    {
        number.LessEqual = lessEqual;
        return number;
    }

    public static T GreaterThen<T>(this T number, double greaterThen) where T : IJsonSchemaNumberBuildContext
    {
        number.GreaterThan = greaterThen;
        return number;
    }

    public static T GreaterThenOrEqualTo<T>(this T number, double greaterEqual) where T : IJsonSchemaNumberBuildContext
    {
        number.GreaterEqual = greaterEqual;
        return number;
    }
}