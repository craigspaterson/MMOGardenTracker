using AutoMapper;
using GT.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GT.Web.Api
{
    /// <summary>
    /// Class Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add CORS
            services.AddCors();

            services.AddControllers();

            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<GardenTrackerAppContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("GardenTrackerAppConnection"));
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            // Add Swagger
            services.AddSwaggerGen(c =>
            {
                //c.DescribeAllEnumsAsStrings();
                c.DescribeAllParametersInCamelCase();
                c.IgnoreObsoleteActions();
                c.IgnoreObsoleteProperties();

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
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
