using Microsoft.AspNetCore.Builder;
using Cefalo.Media.MyBlog.ExtensionServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Models;
using Repositories.Interfaces;
using Repositories;
using Services.Interfaces;
using Services;
using Services.Mapper;

namespace Cefalo.Media.MyBlog
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

            services.DatabaseConfigurationService(Configuration);
            services.CORSConfigurationServices();
            services.AddControllers();
           // services.AddMvc();
            services.AddAutoMapper(typeof(BlogProfile));
            services.SwaggerConfigurationServices();

            services.AddScoped<IStoryRepository, StoryRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            services.AddScoped<IStoryService, StoryService>();
            services.AddScoped<IAuthorService, AuthorService>();

            services.AddControllers(options => { options.RespectBrowserAcceptHeader = true; });
            services.AddControllers(options => { options.RespectBrowserAcceptHeader = true; }).AddNewtonsoftJson();
            services.AddControllers(options => { options.RespectBrowserAcceptHeader = true; }).AddXmlDataContractSerializerFormatters();
            services.AddControllers(options => { options.RespectBrowserAcceptHeader = true; }).AddXmlSerializerFormatters();
            //services.AddControllers(options =>
            //{
            //    options.RespectBrowserAcceptHeader = true;
            //}).AddXmlSerializerFormatters();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cefalo.Media.MyBlog v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
