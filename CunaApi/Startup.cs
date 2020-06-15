using CunaApi.Interfaces;
using CunaApi.Models;
using CunaApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CunaApi
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

            services.AddScoped<IRequestHandlerService, RequestHandlerService>();
            services.AddScoped<IThirdPartyApiService, ThirdPartyApiService>();
            services.AddScoped<IRepositoryService, RepositoryService>();

            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });

            services.AddHttpClient(Constants.ThirdPartyClientName, c =>
            {
                c.BaseAddress = new Uri(Constants.ThirdPartyUrl);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Specify exception handling here. It's quick and easy to implement. Could implement custom exception handling
                // at a later date without refactoring
                app.UseExceptionHandler("/Error");
            
            }
            app.UseMvc();
        }
    }
}
