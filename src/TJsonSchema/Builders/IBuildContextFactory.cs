namespace TJsonSchema.Builders;

public interface IBuildContextFactory<TSelf>
    where TSelf : IBuildContextFactory<TSelf>
{
    public static abstract IJsonSchemaRootBuildContext<TSelf> CreateRootBuildContext();
    
    public static abstract IJsonSchemaObjectBuildContext<TSelf> CreateObjectBuildContext();
    
    public static abstract IJsonSchemaArrayBuildContext<TSelf> CreateArrayBuildContext();
    
    public static abstract IJsonSchemaStringBuildContext CreateStringBuildContext();
    
    public static abstract IJsonSchemaNumberBuildContext CreateNumberBuildContext();

    public static abstract IJsonSchema BuildSchema(IJsonSchemaRootBuildContext<TSelf> root);
}