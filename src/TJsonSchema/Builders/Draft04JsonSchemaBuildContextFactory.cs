using System;
using System.Collections.Generic;
using TJsonSchema.Json;
using TJsonSchema.Schema;

namespace TJsonSchema.Builders;

public abstract class Draft04JsonSchemaBuildContextFactory : JsonSchemaBuildContextFactoryBase,
    IBuildContextFactory<Draft04JsonSchemaBuildContextFactory>
{
    public static IJsonSchemaRootBuildContext<Draft04JsonSchemaBuildContextFactory> CreateRootBuildContext()
    {
        return new Draft04JsonSchemaRootBuildContext();
    }

    public static IJsonSchemaObjectBuildContext<Draft04JsonSchemaBuildContextFactory> CreateObjectBuildContext()
    {
        return new Draft04JsonSchemaObjectBuildContext();
    }

    public static IJsonSchemaArrayBuildContext<Draft04JsonSchemaBuildContextFactory> CreateArrayBuildContext()
    {
        return new Draft04JsonSchemaArrayBuildContext();
    }

    public static IJsonSchemaStringBuildContext CreateStringBuildContext()
    {
        return new Draft04JsonSchemaStringBuildContext();
    }

    public static IJsonSchemaNumberBuildContext CreateNumberBuildContext()
    {
        return new Draft04JsonSchemaNumberBuildContext();
    }

    public static IJsonSchema BuildSchema(JsonSchemaBuildContext<Draft04JsonSchemaBuildContextFactory> root)
    {
        return new Draft04JsonSchema
        {
            ID = root.ID,
            Schema = root.Kind is null ? EmptyJsonSchema.Instance : BuildSchema(root.Kind),
        };
    }

    public static IJsonSchema BuildSchema(IJsonSchemaRootBuildContext<Draft04JsonSchemaBuildContextFactory>? root)
    {
        return root is { Kind: null } ? EmptyJsonSchema.Instance : BuildSchema(root!.Kind);
    }

    public static IJsonSchema BuildSchema(IJsonSchemaBuildContext kind)
    {
        switch (kind)
        {
            case IJsonSchemaObjectBuildContext<Draft04JsonSchemaBuildContextFactory> obj:
            {
                var list = new List<IJsonSchema<IJsonObject>>();
                Append(list, obj);

                return list.Count == 0
                    ? EmptyJsonSchema<IJsonObject>.Instance
                    : new JsonSchemaAggregate<IJsonObject>(list);
            }
            case IJsonSchemaArrayBuildContext<Draft04JsonSchemaBuildContextFactory> array:
            {
                var list = new List<IJsonSchema<IJsonArray>>();
                Append(list, array);

                return list.Count == 0
                    ? EmptyJsonSchema<IJsonArray>.Instance
                    : new JsonSchemaAggregate<IJsonArray>(list);
            }

            case IJsonSchemaStringBuildContext @string:
            {
                var list = new List<IJsonSchema<IJsonString>>();
                Append(list, @string);

                return list.Count == 0
                    ? EmptyJsonSchema<IJsonString>.Instance
                    : new JsonSchemaAggregate<IJsonString>(list);
            }
            case IJsonSchemaNumberBuildContext number:
            {
                var list = new List<IJsonSchema<IJsonNumber>>();
                Append(list, number);

                return list.Count == 0
                    ? EmptyJsonSchema<IJsonNumber>.Instance
                    : new JsonSchemaAggregate<IJsonNumber>(list);
            }
            default:
                throw new InvalidOperationException();
        }
    }

    private sealed class Draft04JsonSchemaRootBuildContext
        : JsonSchemaRootBuildContextBase<Draft04JsonSchemaBuildContextFactory>;

    private sealed class Draft04JsonSchemaObjectBuildContext
        : JsonSchemaObjectBuildContextBase<Draft04JsonSchemaBuildContextFactory>;

    private sealed class Draft04JsonSchemaArrayBuildContext
        : JsonSchemaArrayBuildContextBase<Draft04JsonSchemaBuildContextFactory>;

    private sealed class Draft04JsonSchemaStringBuildContext
        : JsonSchemaStringBuildContextBase<Draft04JsonSchemaBuildContextFactory>;

    private sealed class Draft04JsonSchemaNumberBuildContext
        : JsonSchemaNumberBuildContextBase<Draft04JsonSchemaBuildContextFactory>;

    private sealed class Draft04JsonSchema : IJsonSchema
    {
        public string? ID { get; init; }

        public string? Description { get; init; }

        public required IJsonSchema Schema { get; init; }

        public bool Validate(IJsonNode? node) => Schema.Validate(node);
    }
}