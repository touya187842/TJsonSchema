using System;

namespace TJsonSchema.Builders;

public interface IJsonSchemaRootBuilder
{
    internal string? Description { get; set; }

    public IJsonSchema Build();
}
