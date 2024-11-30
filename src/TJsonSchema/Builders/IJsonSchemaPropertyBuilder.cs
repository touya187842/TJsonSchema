using System.Collections.Generic;

namespace TJsonSchema.Builders;

public interface IJsonSchemaPropertyBuilder
{
    public string Name { get; set; }
    
    public IJsonSchemaRootBuilder Property { get; set; }
    
    internal ICollection<object>? Dependencies { get; set; }
    
    internal bool? IsRequired { get; set; }
}
