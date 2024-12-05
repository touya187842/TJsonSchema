using System.Collections.Generic;

namespace TJsonSchema.Json;

public interface IJsonArray : IJsonNode, IReadOnlyList<IJsonNode?>
{
}