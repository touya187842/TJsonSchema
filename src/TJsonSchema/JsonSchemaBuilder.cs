using TJsonSchema.Builders;

namespace TJsonSchema;

public abstract class JsonSchemaBuilder
{
    public static JsonSchemaBuildContext<Draft04JsonSchemaBuildContextFactory> CreateFromDraft04() =>
        new JsonSchemaBuildContext<Draft04JsonSchemaBuildContextFactory>();
}