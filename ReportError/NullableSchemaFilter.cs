using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class NullableSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Properties == null)
        {
            return;
        }

        foreach (var property in schema.Properties)
        {
            if (property.Value.Type == "string" || 
                property.Value.Type == "integer" || 
                property.Value.Type == "number") 
            {
                property.Value.Nullable = true;
            }
        }
    }
}