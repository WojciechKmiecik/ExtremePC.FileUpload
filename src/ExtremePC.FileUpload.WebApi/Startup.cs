using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ExtremePC.FileUpload.Database;
using ExtremePC.FileUpload.Services;
using ExtremePC.FileUpload.WebApi.ErrorHandling;
using ExtremePC.FileUpload.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ExtremePC.FileUpload.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<FormOptions>(x =>
            {
                x.MultipartBodyLengthLimit = 209715200;
            });
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Info { Title = "FileUpload API", Version = "v1" });


                var docFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, docFile);

                if (File.Exists(filePath))
                    config.IncludeXmlComments(filePath);
            });

            RegisterIoCContainer(ref services);
        }

        public void RegisterIoCContainer(ref IServiceCollection services)
        {
                services.AddDbContext<FileUploadDBContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddTransient<IProcessUploadedFileService, ProcessUploadedFileService>();
            services.AddTransient<INormalizeDataService, NormalizeDataService>();
            services.AddTransient<IDatabaseService, DatabaseService>();
            services.AddTransient<IDataParserService, DataParserService>();
        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
                app.ConfigureExceptionHandler(loggerFactory.CreateLogger("Global"));
            }

            //app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FileUpload API");
            });

            // default to swagger endpoint
            var routeBuilder = new RouteBuilder(app);
            routeBuilder.MapGet(string.Empty, ctx =>
            {
                ctx.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });
            app.UseRouter(routeBuilder.Build());

            loggerFactory.AddFile("Logs/ExtremePC.FileUpload.WebApi-{Date}.txt");
        }
    }
}
