using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Gooders.Services.WebApi.Configuration.Swagger;

public static class SwaggerConfig
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddSwaggerGen(s =>
        {
            s.OperationFilter<EnableQueryFilter>();

            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "EasyDocs API",
                Description = "Interface Swagger Services API for EasyDocs product",
                Contact = new OpenApiContact { Name = "Enzo Godoy", Email = "enzo.godoy@go-it.work" }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            s.IncludeXmlComments(xmlPath);
        });
    }

    public static void UseSwaggerSetup(this IApplicationBuilder app)
    {
        if (app == null) throw new ArgumentNullException(nameof(app));

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });
    }
}