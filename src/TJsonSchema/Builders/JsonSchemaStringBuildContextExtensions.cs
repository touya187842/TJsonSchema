using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace TJsonSchema.Builders;

public static class JsonSchemaStringBuildContextExtensions
{
    public static IJsonSchemaStringBuildContext AsString<TFactory>(this IJsonSchemaRootBuildContext<TFactory> context)
        where TFactory : IBuildContextFactory<TFactory>
    {
        switch (context)
        {
            case { Kind: null }:
            {
                var @string = TFactory.CreateStringBuildContext();
                context.Kind = @string;
                return @string;
            }
            case { Kind: IJsonSchemaStringBuildContext @string }:
            {
                return @string;
            }
            default:
                throw new InvalidOperationException();
        }
    }

    public static T MaxLength<T>(this T @string, int maxLength) where T : IJsonSchemaStringBuildContext
    {
        @string.MaxLength = maxLength;
        return @string;
    }

    public static T MinLength<T>(this T @string, int minLength) where T : IJsonSchemaStringBuildContext
    {
        @string.MinLength = minLength;
        return @string;
    }

    public static T Match<T>(this T @string, [StringSyntax(StringSyntaxAttribute.Regex)] string pattern)
        where T : IJsonSchemaStringBuildContext
    {
        @string.Pattern = new Regex(pattern);
        return @string;
    }
}