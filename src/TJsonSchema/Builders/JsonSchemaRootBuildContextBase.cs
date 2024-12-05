namespace TJsonSchema.Builders;

public abstract class JsonSchemaRootBuildContextBase<T> 
    : IJsonSchemaRootBuildContext<T>
    where T : IBuildContextFactory<T>
{
    public IJsonSchemaBuildContext? Kind { get; set; }

    public virtual IJsonSchema Build()
    {
        return T.BuildSchema(this);
    }
}