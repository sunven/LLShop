﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Swashbuckle.AspNetCore.Swagger;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.TagHelpers.LayUI;
using System.Collections.Generic;

namespace LLShop
{
    public class Program
    {

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(x =>
                {
                    x.AddFrameworkService();
                    x.AddLayui();
                    x.AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                        c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                        {
                            Description = "JWT Bearer",
                            Name = "Authorization",
                            In = "header",
                            Type = "apiKey"
                        });
                        c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                        {
                            { "Bearer", new string[] { } }
                        });
                    });
                    x.AddSpaStaticFiles(configuration =>
                    {
                        configuration.RootPath = "ClientApp/build";
                    });
                })
                .Configure(x =>
                {
                    var env = x.ApplicationServices.GetService<IHostingEnvironment>();
                    x.UseSwagger();
                    x.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    });
                    x.UseSpaStaticFiles();
                    x.UseFrameworkService();
                    x.UseSpa(spa =>
                    {
                        spa.Options.SourcePath = "ClientApp";                        
                        if (env.IsDevelopment())
                        {
                            spa.UseReactDevelopmentServer(npmScript: "start");
                        }
                    });

                })
                .Build();

    }
}