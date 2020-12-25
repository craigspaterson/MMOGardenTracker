using AutoMapper;
using FluentValidation.AspNetCore;
using GT.Domain;
using GT.Web.Api.Configuration;
using GT.Web.Api.Filters;
using GT.Web.Api.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GT.Web.Api
{
    /// <summary>
    /// Class Startup.
    /// </summary>
    public class Startup
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add CORS
            services.AddCors();

            services.AddControllers(opts =>
                {
                    opts.Filters.Add(typeof(GlobalExceptionFilter));
                })
                .AddFluentValidation(opts =>
                {
                    opts.RegisterValidatorsFromAssemblyContaining<GardenValidator>(lifetime: ServiceLifetime.Singleton);
                    opts.ImplicitlyValidateChildProperties = true;
                })

                .AddJsonOptions(opts =>
                {
                    opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                    opts.JsonSerializerOptions.WriteIndented = true;
                    opts.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });

            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContextPool<GardenTrackerAppContext>(opts =>
            {
                // opts.UseSqlServer(_configuration.GetConnectionString("GardenTrackerAppConnection"));
                opts.UseNpgsql(_configuration.GetConnectionString("GardenTrackerAppConnection"));
            });

            // Add Repositories
            services.AddRepositories();

            // Register the Swagger generator, defining 1 or more Swagger documents
            // Add Swagger
            services.AddSwaggerGen(opts =>
            {
                opts.DescribeAllParametersInCamelCase();
                opts.IgnoreObsoleteActions();
                opts.IgnoreObsoleteProperties();

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opts.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable cross origin requests
            app.UseCors(c =>
                {
                    c.AllowAnyHeader();
                    c.AllowAnyMethod();
                    c.AllowAnyOrigin();
                }
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Write streamlined request completion events, instead of the more verbose ones from the framework.
            // To use the default framework request logging instead, remove this line and set the "Microsoft"
            // level in appsettings.json to "Information".
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Insert middleware to expose the generated Swagger as JSON endpoint(s)
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GT.Web.Api");
            });
        }

        /// <summary>
        /// Class RemoveVersionFromParameter.
        /// Implements the <see cref="Swashbuckle.AspNetCore.SwaggerGen.IOperationFilter" />
        /// </summary>
        /// <seealso cref="Swashbuckle.AspNetCore.SwaggerGen.IOperationFilter" />
        public class RemoveVersionFromParameter : IOperationFilter
        {
            /// <summary>
            /// Applies the specified operation.
            /// </summary>
            /// <param name="operation">The operation.</param>
            /// <param name="context">The context.</param>
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                var versionParameter = operation.Parameters.Single(p => p.Name == "version");
                operation.Parameters.Remove(versionParameter);
            }
        }

        /// <summary>
        /// Class ReplaceVersionWithExactValueInPath.
        /// Implements the <see cref="Swashbuckle.AspNetCore.SwaggerGen.IDocumentFilter" />
        /// </summary>
        /// <seealso cref="Swashbuckle.AspNetCore.SwaggerGen.IDocumentFilter" />
        public class ReplaceVersionWithExactValueInPath : IDocumentFilter
        {
            /// <summary>
            /// Applies the specified swagger document.
            /// </summary>
            /// <param name="swaggerDoc">The swagger document.</param>
            /// <param name="context">The context.</param>
            public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
            {
                var paths = new OpenApiPaths();
                foreach (var path in swaggerDoc.Paths)
                {
                    paths.Add(path.Key.Replace("v{version}", swaggerDoc.Info.Version), path.Value);
                }
                swaggerDoc.Paths = paths;
            }
        }
    }
}
