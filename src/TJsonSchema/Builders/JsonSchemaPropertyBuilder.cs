using System.Collections.Generic;

namespace TJsonSchema.Builders;

internal class JsonSchemaPropertyBuilder : IJsonSchemaPropertyBuilder
{
    public required string Name { get; set; }
    
    public required IJsonSchemaRootBuilder Property { get; set; }
    
    public ICollection<object>? Dependencies { get; set; }
    
    public bool? IsRequired { get; set; }
}