using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using QualityManagement.API.Extensions;
using QualityManagement.Map.InjecaoDependencias;

namespace QualityManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            services.AddApplicationInsightsTelemetry();

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Quality Management API", Version = "v1" });
                options.CustomOperationIds(e => $"{string.Join("", e.ActionDescriptor.RouteValues.Values)}");
            });

            services.AddMvc();

            services.AddResponseCompression(options =>
            {
                options.MimeTypes = new[]{
                    "text/html",
                    "text/css",
                    "application/javascript",
                    "text/javascript",
                    "application/json"
                };
                options.EnableForHttps = true;
            });

            InjecaoDependencias.Configurar(services);

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGlobalExceptionHandler(loggerFactory);
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGlobalExceptionHandler(loggerFactory);

            app.UseHttpsRedirection();

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "QualityManagement.API");
            });

            app.UseRouting().
                UseAuthorization().
                UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
