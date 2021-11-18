using Framework.Service.Interfaces;
using Framework.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Framework.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add swagger documentation
            services.AddSwaggerGen(swagger =>
            {
                swagger.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Framework Services API",
                    Version = "v1"
                });

                swagger.CustomSchemaIds(x => x.FullName);
                swagger.DescribeAllParametersInCamelCase();

                var XMLPath = AppDomain.CurrentDomain.BaseDirectory + "Framework.Application" + ".xml";

                if (File.Exists(XMLPath))
                {
                    swagger.IncludeXmlComments(XMLPath);
                }

                string basePath = AppContext.BaseDirectory;

                Directory.GetFiles(string.Format("{0}/", basePath), "*.xml").ToList().ForEach(file =>
                {
                    swagger.IncludeXmlComments(file, true);
                });
            });

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddOptions();
            services.AddResponseCaching();
            services.AddControllers()
                .AddJsonOptions(opts =>
                {
                    opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.Formatting = Formatting.Indented;
                    opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opts.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });
            services.AddMediatR(typeof(Startup));
            services.AddTransient<IMathService, MathService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseWelcomePage("/");
            app.UseWebSockets();
            app.UseResponseCaching();

            app.UseSwagger();
            app.UseSwaggerUI(ui =>
            {
                ui.SwaggerEndpoint("v1/swagger.json", "Framework Services API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
