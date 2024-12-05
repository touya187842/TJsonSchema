using System;

namespace TJsonSchema.Builders;

public static class JsonSchemaRootBuildContextExtensions
{
    public static T Description<T>(this T schema, string description) where T : IJsonSchemaBuildContext
    {
        schema.Description = description;
        return schema;
    }
}