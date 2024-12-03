using System.Collections.Generic;

namespace TJsonSchema.Builders;

internal class JsonSchemaPropertyBuildContext : IJsonSchemaPropertyBuildContext
{
    public required string Name { get; set; }
    
    public required IJsonSchemaBuildContext Property { get; set; }
    
    public ICollection<object>? Dependencies { get; set; }
    
    public bool? IsRequired { get; set; }
}