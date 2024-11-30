using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace TJsonSchema.Builders;

public static class JsonSchemaStringBuilderExtensions
{
    public static T MaxLength<T>(this T @string, int maxLength) where T : IJsonSchemaStringBuilder
    {
        @string.MaxLength = maxLength;
        return @string;
    }

    public static T MinLength<T>(this T @string, int minLength) where T : IJsonSchemaStringBuilder
    {
        @string.MinLength = minLength;
        return @string;
    }

    public static T Match<T>(this T @string, [StringSyntax(StringSyntaxAttribute.Regex)] string pattern)
        where T : IJsonSchemaStringBuilder
    {
        @string.Pattern = new Regex(pattern);
        return @string;
    }
}