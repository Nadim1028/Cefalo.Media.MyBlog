using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Cefalo.Media.MyBlog.ExtensionServices
{
    public static class SwaggerConfiguration
    {
        public static void SwaggerConfigurationServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cefalo.Media.BlogProject", Version = "v1" });
            });
        }
    }
}
