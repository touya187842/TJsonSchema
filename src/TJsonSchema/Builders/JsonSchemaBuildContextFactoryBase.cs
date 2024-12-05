using System.Collections.Generic;
using System.Linq;
using TJsonSchema.Json;
using TJsonSchema.Schema;

namespace TJsonSchema.Builders;

public abstract class JsonSchemaBuildContextFactoryBase
{
    private protected static void Append<TFactory>(
        ICollection<IJsonSchema<IJsonObject>> list,
        IJsonSchemaObjectBuildContext<TFactory> obj)
        where TFactory : IBuildContextFactory<TFactory>
    {
        if (obj.MinProperties.HasValue)
        {
            list.Add(new JsonSchemaObjectMinProperty(obj.MinProperties.Value));
        }

        if (obj.MaxProperties.HasValue)
        {
            list.Add(new JsonSchemaObjectMaxProperty(obj.MaxProperties.Value));
        }

        if (obj.Properties is not null)
        {
            foreach ((var propertyName, var property) in obj.Properties)
            {
                Append(list, propertyName, property);
            }
        }
    }

    private static void Append<TFactory>(
        ICollection<IJsonSchema<IJsonObject>> list,
        string propertyName,
        IJsonSchemaPropertyBuildContext<TFactory> property)
        where TFactory : IBuildContextFactory<TFactory>
    {
        if (property.IsRequired.HasValue && property.IsRequired.Value)
        {
            list.Add(new JsonSchemaPropertyRequired(propertyName));
        }

        if (property.Dependencies is not null)
        {
            foreach (var dependny in property.Dependencies
                         .OfType<string>().Where(s => string.IsNullOrEmpty(s) is false))
            {
                list.Add(new JsonSchemaPropertyDependency(propertyName, dependny));
            }
        }

        list.Add(new JsonSchemaObjectProperty(propertyName,
            TFactory.BuildSchema(property.Property)));
    }

    private protected static void Append<TFactory>(
        List<IJsonSchema<IJsonArray>> list,
        IJsonSchemaArrayBuildContext<TFactory> array)
        where TFactory : IBuildContextFactory<TFactory>
    {
        if (array.MinItems.HasValue)
        {
            list.Add(new JsonSchemaArrayMinItems(array.MinItems.Value));
        }

        if (array.MaxItems.HasValue)
        {
            list.Add(new JsonSchemaArrayMaxItems(array.MaxItems.Value));
        }

        if (array.MustUniqueItems.HasValue)
        {
            list.Add(new JsonSchemaArrayUniqueItems());
        }

        if (array.Items is { Count: > 0 })
        {
            list.Add(new JsonSchemaArraySequence(array.Items.Select(TFactory.BuildSchema).ToArray()));
        }

        if (array.AllowAdditionalItemSchema is not null)
        {
            list.Add(new JsonSchemaArrayAdditionItems(
                TFactory.BuildSchema(array.AllowAdditionalItemSchema),
                array.Items is { Count: > 0 } ? array.Items.Count : 0));
        }
    }

    private protected static void Append(ICollection<IJsonSchema<IJsonString>> list,
        IJsonSchemaStringBuildContext @string)
    {
        if (@string.MinLength.HasValue)
        {
            list.Add(new JsonSchemaStringMinLength(@string.MinLength.Value));
        }

        if (@string.MaxLength.HasValue)
        {
            list.Add(new JsonSchemaStringMaxLength(@string.MaxLength.Value));
        }

        if (@string.Pattern is not null)
        {
            list.Add(new JsonSchemaStringPattern(@string.Pattern));
        }

        if (@string.Format is not null)
        {
            list.Add(new Schema.JsonSchemaStringFormat(@string.Format));
        }
    }

    private protected static void Append(ICollection<IJsonSchema<IJsonNumber>> list,
        IJsonSchemaNumberBuildContext number)
    {
        if (number.LessThan.HasValue)
        {
            list.Add(new JsonSchemaNumberLessThan(number.LessThan.Value));
        }

        if (number.LessEqual.HasValue)
        {
            list.Add(new JsonSchemaNumberLessEqual(number.LessEqual.Value));
        }

        if (number.GreaterThan.HasValue)
        {
            list.Add(new JsonSchemaNumberGreaterThan(number.GreaterThan.Value));
        }

        if (number.GreaterEqual.HasValue)
        {
            list.Add(new JsonSchemaNumberGreaterEqual(number.GreaterEqual.Value));
        }

        if (number.MultipleOf.HasValue)
        {
            list.Add(new JsonSchemaNumberMulipleOf(number.MultipleOf.Value));
        }
    }
}