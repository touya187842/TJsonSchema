namespace TJsonSchema.Builders;

internal interface IJsonSchemaUnkindBuildContext : IJsonSchemaRootBuildContext
{
    internal IJsonSchemaRootBuildContext? Kind { get; set; }
}