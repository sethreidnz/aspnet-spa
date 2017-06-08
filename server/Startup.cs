using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DotnetSpa
{
   public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            HostingEnvironment = env;
            Configuration = builder.Build();
        }
        public IHostingEnvironment HostingEnvironment { get; private set; }
        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
        if (HostingEnvironment.IsDevelopment())
        {
            services.AddCors(options => options.AddPolicy("AllowDevelopment", 
                p => p.WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()));
        }
            services.AddOptions();
            services.AddMvc();
        }
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            
            if (HostingEnvironment.IsDevelopment())
            {
                app.UseCors("AllowDevelopment");
            }

            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                }
            });

            app.UseMvc();
            app.UseDefaultFiles(options);
            app.UseStaticFiles();
        }
    }
}
