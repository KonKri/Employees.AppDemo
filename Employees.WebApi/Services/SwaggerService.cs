using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Employees.WebApi.Services
{
    /// <summary>
    /// adds swagger extensions
    /// </summary>
    public static class SwaggerServiceCollectionExtension
    {
        /// <summary>
        /// Add swagger service
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Info { Title = "Employees.WebApi API" });

                config.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    In = "header",
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = "apiKey"
                });

                config.OperationFilter<SecurityRequirementsOperationFilter>(true, "Bearer");

                //config.AddSecurityRequirement()

                var xmlCommentsFile = $"{AppContext.BaseDirectory}/{ Assembly.GetExecutingAssembly().GetName().Name}.xml";
                config.IncludeXmlComments(xmlCommentsFile);
            });

            return services;
        }
    }
}
