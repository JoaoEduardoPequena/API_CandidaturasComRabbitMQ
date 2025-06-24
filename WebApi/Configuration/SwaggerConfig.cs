using Microsoft.OpenApi.Models;

namespace WebApi.Configuration
{
    public static class SwaggerConfig
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(d =>
            {
                d.SwaggerDoc("candidaturas", new OpenApiInfo
                {
                    Title = "Web API Gestão de Candidaturas",
                    Version = "v1",
                    Description =
                        "Documentaçao Referente api para gestão de candidaturas",
                });

            });
        }
    }
}
