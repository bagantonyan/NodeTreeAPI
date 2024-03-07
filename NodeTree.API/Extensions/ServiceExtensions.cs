using Microsoft.OpenApi.Models;
using System.Reflection;

namespace NodeTree.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(configs =>
            {
                configs.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "NodeTree API",
                    Version = "v1",
                    Description = "An API for working with tree of nodes and with journal of exceptions",
                    Contact = new OpenApiContact
                    {
                        Name = "Bagrat Antonyan - Github",
                        Url = new Uri("https://github.com/bagantonyan")
                    }
                });

                configs.EnableAnnotations();

                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                configs.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName), true);
            });
        }
    }
}