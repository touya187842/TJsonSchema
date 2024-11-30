namespace TJsonSchema.Builders;

internal interface IJsonSchemaUnkindBuilder : IJsonSchemaRootBuilder
{
    internal IJsonSchemaRootBuilder? Kind { get; set; }
}