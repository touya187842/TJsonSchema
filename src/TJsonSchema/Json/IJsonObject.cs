using System.Collections.Generic;

namespace TJsonSchema.Json;

public interface IJsonObject : IJsonNode, IReadOnlyDictionary<string, IJsonNode?>
{
}