namespace TJsonSchema.Builders;

public interface IBuildContextFactory<TSelf>
    where TSelf : IBuildContextFactory<TSelf>
{
    public static abstract IJsonSchemaRootBuildContext<TSelf> CreateRootBuildContext();
}